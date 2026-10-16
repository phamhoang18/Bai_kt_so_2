namespace Bai3_MdiSupermarket
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            mnuLogout = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuCatalog = new ToolStripMenuItem();
            mnuProducts = new ToolStripMenuItem();
            mnuStock = new ToolStripMenuItem();
            mnuReport = new ToolStripMenuItem();
            mnuRevenue = new ToolStripMenuItem();
            mnuWindow = new ToolStripMenuItem();
            mnuCascade = new ToolStripMenuItem();
            mnuTileH = new ToolStripMenuItem();
            mnuTileV = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tslUser = new ToolStripStatusLabel();
            tslStatus = new ToolStripStatusLabel();
            tslSync = new ToolStripStatusLabel();
            tspbLoading = new ToolStripProgressBar();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuCatalog, mnuReport, mnuWindow });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = mnuWindow;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1143, 30);
            menuStrip1.TabIndex = 0;
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuLogout, mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(85, 24);
            mnuSystem.Text = "Hệ thống";
            // 
            // mnuLogout
            // 
            mnuLogout.Name = "mnuLogout";
            mnuLogout.Size = new Size(160, 26);
            mnuLogout.Text = "Đăng xuất";
            mnuLogout.Click += mnuLogout_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(160, 26);
            mnuExit.Text = "Thoát";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuCatalog
            // 
            mnuCatalog.DropDownItems.AddRange(new ToolStripItem[] { mnuProducts, mnuStock });
            mnuCatalog.Name = "mnuCatalog";
            mnuCatalog.Size = new Size(90, 24);
            mnuCatalog.Text = "Danh mục";
            // 
            // mnuProducts
            // 
            mnuProducts.Name = "mnuProducts";
            mnuProducts.Size = new Size(214, 26);
            mnuProducts.Text = "Quản lý Sản phẩm";
            mnuProducts.Click += mnuProducts_Click;
            // 
            // mnuStock
            // 
            mnuStock.Name = "mnuStock";
            mnuStock.Size = new Size(214, 26);
            mnuStock.Text = "Quản lý Nhập xuất";
            mnuStock.Click += mnuStock_Click;
            // 
            // mnuReport
            // 
            mnuReport.DropDownItems.AddRange(new ToolStripItem[] { mnuRevenue });
            mnuReport.Name = "mnuReport";
            mnuReport.Size = new Size(77, 24);
            mnuReport.Text = "Báo cáo";
            // 
            // mnuRevenue
            // 
            mnuRevenue.Name = "mnuRevenue";
            mnuRevenue.Size = new Size(226, 26);
            mnuRevenue.Text = "Thống kê Doanh thu";
            mnuRevenue.Click += mnuRevenue_Click;
            // 
            // mnuWindow
            // 
            mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { mnuCascade, mnuTileH, mnuTileV });
            mnuWindow.Name = "mnuWindow";
            mnuWindow.Size = new Size(68, 24);
            mnuWindow.Text = "Cửa sổ";
            // 
            // mnuCascade
            // 
            mnuCascade.Name = "mnuCascade";
            mnuCascade.Size = new Size(190, 26);
            mnuCascade.Text = "Cascade";
            mnuCascade.Click += mnuCascade_Click;
            // 
            // mnuTileH
            // 
            mnuTileH.Name = "mnuTileH";
            mnuTileH.Size = new Size(190, 26);
            mnuTileH.Text = "Tile Horizontal";
            mnuTileH.Click += mnuTileH_Click;
            // 
            // mnuTileV
            // 
            mnuTileV.Name = "mnuTileV";
            mnuTileV.Size = new Size(190, 26);
            mnuTileV.Text = "Tile Vertical";
            mnuTileV.Click += mnuTileV_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslUser, tslStatus, tslSync, tspbLoading });
            statusStrip1.Location = new Point(0, 837);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1143, 30);
            statusStrip1.TabIndex = 1;
            // 
            // tslUser
            // 
            tslUser.Name = "tslUser";
            tslUser.Size = new Size(138, 24);
            tslUser.Text = "Người dùng: admin";
            // 
            // tslStatus
            // 
            tslStatus.BorderSides = ToolStripStatusLabelBorderSides.Left;
            tslStatus.Name = "tslStatus";
            tslStatus.Size = new Size(665, 24);
            tslStatus.Spring = true;
            tslStatus.Text = "Sẵn sàng";
            tslStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tslSync
            // 
            tslSync.BorderSides = ToolStripStatusLabelBorderSides.Left;
            tslSync.Name = "tslSync";
            tslSync.Size = new Size(145, 24);
            tslSync.Text = "Đồng bộ: chưa chạy";
            // 
            // tspbLoading
            // 
            tspbLoading.Name = "tspbLoading";
            tspbLoading.Size = new Size(137, 22);
            tspbLoading.Style = ProgressBarStyle.Marquee;
            tspbLoading.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 867);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý siêu thị";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalog;
        private System.Windows.Forms.ToolStripMenuItem mnuProducts;
        private System.Windows.Forms.ToolStripMenuItem mnuStock;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuRevenue;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileH;
        private System.Windows.Forms.ToolStripMenuItem mnuTileV;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslUser;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslSync;
        private System.Windows.Forms.ToolStripProgressBar tspbLoading;
    }
}