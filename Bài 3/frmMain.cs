using System;
using System.Windows.Forms;

namespace Bai3_MdiSupermarket
{
    public partial class frmMain : Form
    {
        private int busyCount = 0;                             

        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenChild<T>() where T : Form, new()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)                                
                {
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    child.Activate();                        
                    return;
                }
            }

            T newChild = new T();                            
            newChild.MdiParent = this;                          
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
                foreach (Form child in this.MdiChildren)        
                    child.Close();

                tslUser.Text = "Người dùng: (đã đăng xuất)";
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);               
        }

        private void mnuTileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);        
        }

        private void mnuTileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);             
        }

        // ===== Các hàm công khai cho form con gọi (luôn gọi từ UI thread) =====

        public void SetBusy(bool busy)
        {
            busyCount += busy ? 1 : -1;
            if (busyCount < 0) busyCount = 0;

            tspbLoading.Visible = busyCount > 0;                 
            tslStatus.Text = busyCount > 0 ? "Đang xử lý dữ liệu..." : "Sẵn sàng";
        }

        public void SetSyncText(string text)
        {
            tslSync.Text = text;
        }
    }
}
