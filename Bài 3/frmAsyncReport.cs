using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3_MdiSupermarket
{
    public class RevenueRow
    {
        public string Month { get; set; } = "";
        public int Orders { get; set; }
        public decimal Revenue { get; set; }
    }

    public partial class frmAsyncReport : Form
    {
        private int clickCount = 0;                            
        private int totalNewOrders = 0;                        
        private CancellationTokenSource syncCts = null;          

        public frmAsyncReport()
        {
            InitializeComponent();
        }

        private void frmAsyncReport_Load(object sender, EventArgs e)
        {
            dgvSync.Columns.Add("colTime", "Thời gian");
            dgvSync.Columns.Add("colRate", "Tỷ giá");
            dgvSync.Columns.Add("colOrders", "Đơn mới");

            StartSync();                                       
        }

        private void frmAsyncReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopSync();
        }

        private async void btnLoadReport_Click(object sender, EventArgs e)
        {
            frmMain main = this.MdiParent as frmMain;            // Lưu lại form cha để còn dùng sau khi await

            btnLoadReport.Enabled = false;                       // Chặn bấm lặp lúc đang tải
            lblReportStatus.Text = "Đang tải báo cáo...";
            main?.SetBusy(true);                                 // Bật ProgressBar trên StatusStrip của form cha

            try
            {
                List<RevenueRow> rows = await Task.Run(() => BuildRevenueReport());

                if (this.IsDisposed) return;                  

                dgvReport.DataSource = rows;
                FormatReportGrid();
                lblTotal.Text = "Tổng doanh thu: " + rows.Sum(r => r.Revenue).ToString("N0") + " đ";
                lblReportStatus.Text = "Đã tải xong lúc " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                    MessageBox.Show("Tải báo cáo thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                main?.SetBusy(false);                            // Luôn tắt ProgressBar dù thành công hay lỗi
                if (!this.IsDisposed)
                    btnLoadReport.Enabled = true;
            }
        }

        private List<RevenueRow> BuildRevenueReport()
        {
            Random rnd = new Random(2026);
            List<RevenueRow> list = new List<RevenueRow>();

            for (int month = 1; month <= 12; month++)
            {
                Thread.Sleep(300);                               // Giả lập truy xuất CSDL / tính toán nặng (12 x 0.3s = 3.6 giây)

                int orders = rnd.Next(300, 900);
                decimal revenue = orders * rnd.Next(150000, 400000);
                list.Add(new RevenueRow { Month = "Tháng " + month, Orders = orders, Revenue = revenue });
            }
            return list;
        }

        private void FormatReportGrid()
        {
            dgvReport.Columns["Month"].HeaderText = "Tháng";
            dgvReport.Columns["Orders"].HeaderText = "Số đơn hàng";
            dgvReport.Columns["Revenue"].HeaderText = "Doanh thu (đ)";
            dgvReport.Columns["Revenue"].DefaultCellStyle.Format = "N0";
            dgvReport.Columns["Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReport.Columns["Orders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnTestUi_Click(object sender, EventArgs e)
        {
            clickCount++;
            lblClickCount.Text = "Số lần bấm: " + clickCount;
        }

        private void btnToggleSync_Click(object sender, EventArgs e)
        {
            if (syncCts == null)
            {
                StartSync();
            }
            else
            {
                StopSync();
                btnToggleSync.Text = "Bắt đầu đồng bộ";
            }
        }

        private void StartSync()
        {
            syncCts = new CancellationTokenSource();
            CancellationToken token = syncCts.Token;
            btnToggleSync.Text = "Dừng đồng bộ";

            // Task.Run: toàn bộ vòng lặp bên dưới chạy trên thread phụ
            Task.Run(async () =>
            {
                Random rnd = new Random();

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(2000, token);     
                    }
                    catch (OperationCanceledException)
                    {
                        break;                              
                    }

                    // Giả lập dữ liệu "mới" lấy từ server
                    decimal rate = 24500 + rnd.Next(-200, 201);
                    int newOrders = rnd.Next(0, 6);
                    string time = DateTime.Now.ToString("HH:mm:ss");

                    // KHÔNG gán vào control ở đây (đang ở thread phụ), mà gọi hàm có kiểm tra InvokeRequired
                    UpdateSyncUi(time, rate, newOrders);
                }
            }, token);
        }

        private void StopSync()
        {
            if (syncCts != null)
            {
                syncCts.Cancel();                                // Báo cho vòng lặp nền dừng lại
                syncCts = null;
            }
        }

        private void UpdateSyncUi(string time, decimal rate, int newOrders)
        {
            if (this.IsDisposed) return;

            // InvokeRequired = true nghĩa là đang ở thread khác UI thread
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<string, decimal, int>(UpdateSyncUi), time, rate, newOrders);
                }
                catch (ObjectDisposedException) { }              // Form vừa đóng đúng lúc: bỏ qua
                catch (InvalidOperationException) { }            // Handle của form chưa có hoặc đã hủy: bỏ qua
                return;
            }

            totalNewOrders += newOrders;

            lblRate.Text = rate.ToString("N0");
            lblOrders.Text = totalNewOrders.ToString();
            lblLastSync.Text = "Lần đồng bộ gần nhất: " + time;

            dgvSync.Rows.Insert(0, time, rate.ToString("N0"), newOrders);   // Dòng mới nằm trên cùng
            if (dgvSync.Rows.Count > 50)
                dgvSync.Rows.RemoveAt(dgvSync.Rows.Count - 1);              // Giữ tối đa 50 dòng nhật ký

            frmMain main = this.MdiParent as frmMain;
            if (main != null)
                main.SetSyncText("Đồng bộ: " + time + " | USD " + rate.ToString("N0"));
        }
    }
}
