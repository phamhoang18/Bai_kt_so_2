using System;
using System.Windows.Forms;

namespace Bai3_MdiSupermarket
{
    public partial class frmMain : Form
    {
        private int busyCount = 0;                               // Số tác vụ nặng đang chạy (nhiều form con có thể chạy cùng lúc)

        public frmMain()
        {
            InitializeComponent();
        }

        // ===== Scenario A: mở form con, nếu đã mở thì đưa lên trước =====
        // Generic: T là bất kỳ Form nào có constructor không tham số
        private void OpenChild<T>() where T : Form, new()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)                                  // Form kiểu T đã được mở rồi
                {
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    child.Activate();                            // Mang lên trước
                    return;
                }
            }

            T newChild = new T();                                // Chưa có thì tạo mới
            newChild.MdiParent = this;                           // Gán form cha để nó nằm bên trong frmMain
            newChild.Show();
        }

        private void mnuProducts_Click(object sender, EventArgs e)
        {
            OpenChild<frmProductCatalog>();
        }

        private void mnuRevenue_Click(object sender, EventArgs e)
        {
            OpenChild<frmAsyncReport>();
        }

        // Đề bài không có form riêng cho "Nhập xuất"
        private void mnuStock_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Nhập xuất chưa được xây dựng trong phạm vi bài này.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Menu Hệ thống =====
        private void mnuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form child in this.MdiChildren)         // MdiChildren trả về bản sao nên đóng trong vòng lặp an toàn
                    child.Close();

                tslUser.Text = "Người dùng: (đã đăng xuất)";
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===== Menu Cửa sổ =====
        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);                   // Xếp chồng lệch nhau
        }

        private void mnuTileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);            // Xếp ngang (chồng theo chiều dọc)
        }

        private void mnuTileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);              // Xếp dọc (cạnh nhau theo chiều ngang)
        }

        // ===== Các hàm công khai cho form con gọi (luôn gọi từ UI thread) =====

        // Bật/tắt ProgressBar dùng chung
        public void SetBusy(bool busy)
        {
            busyCount += busy ? 1 : -1;
            if (busyCount < 0) busyCount = 0;

            tspbLoading.Visible = busyCount > 0;                 // Còn ít nhất 1 tác vụ thì vẫn hiện
            tslStatus.Text = busyCount > 0 ? "Đang xử lý dữ liệu..." : "Sẵn sàng";
        }

        // Hiển thị thông tin đồng bộ nền lên StatusStrip
        public void SetSyncText(string text)
        {
            tslSync.Text = text;
        }
    }
}