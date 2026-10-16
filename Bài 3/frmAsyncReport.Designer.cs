namespace Bai3_MdiSupermarket
{
    partial class frmAsyncReport
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
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.lblReportStatus = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnTestUi = new System.Windows.Forms.Button();
            this.lblClickCount = new System.Windows.Forms.Label();
            this.grpSync = new System.Windows.Forms.GroupBox();
            this.lblRateCaption = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblOrdersCaption = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblLastSync = new System.Windows.Forms.Label();
            this.btnToggleSync = new System.Windows.Forms.Button();
            this.dgvSync = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.grpSync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSync)).BeginInit();
            this.SuspendLayout();

            // btnLoadReport: bấm để tải báo cáo bất đồng bộ
            this.btnLoadReport.Location = new System.Drawing.Point(15, 15);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(210, 36);
            this.btnLoadReport.TabIndex = 0;
            this.btnLoadReport.Text = "Tải Báo Cáo Doanh Thu";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);

            this.lblReportStatus.AutoSize = true;
            this.lblReportStatus.Location = new System.Drawing.Point(235, 25);
            this.lblReportStatus.Name = "lblReportStatus";
            this.lblReportStatus.Text = "Chưa tải báo cáo";

            // dgvReport
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvReport.Location = new System.Drawing.Point(15, 65);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(450, 290);
            this.dgvReport.TabIndex = 1;

            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(15, 365);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(450, 23);
            this.lblTotal.Text = "Tổng doanh thu: 0 đ";

            // btnTestUi: chứng minh UI vẫn phản hồi trong lúc đang tải
            this.btnTestUi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestUi.Location = new System.Drawing.Point(15, 400);
            this.btnTestUi.Name = "btnTestUi";
            this.btnTestUi.Size = new System.Drawing.Size(210, 32);
            this.btnTestUi.TabIndex = 2;
            this.btnTestUi.Text = "Bấm thử (UI vẫn phản hồi)";
            this.btnTestUi.UseVisualStyleBackColor = true;
            this.btnTestUi.Click += new System.EventHandler(this.btnTestUi_Click);

            this.lblClickCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClickCount.AutoSize = true;
            this.lblClickCount.Location = new System.Drawing.Point(235, 408);
            this.lblClickCount.Name = "lblClickCount";
            this.lblClickCount.Text = "Số lần bấm: 0";

            // grpSync: đồng bộ nền mỗi 2 giây
            this.grpSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSync.Controls.Add(this.lblRateCaption);
            this.grpSync.Controls.Add(this.lblRate);
            this.grpSync.Controls.Add(this.lblOrdersCaption);
            this.grpSync.Controls.Add(this.lblOrders);
            this.grpSync.Controls.Add(this.lblLastSync);
            this.grpSync.Controls.Add(this.btnToggleSync);
            this.grpSync.Controls.Add(this.dgvSync);
            this.grpSync.Location = new System.Drawing.Point(480, 15);
            this.grpSync.Name = "grpSync";
            this.grpSync.Size = new System.Drawing.Size(285, 420);
            this.grpSync.TabStop = false;
            this.grpSync.Text = "Đồng bộ dữ liệu nền (mỗi 2 giây)";

            this.lblRateCaption.AutoSize = true;
            this.lblRateCaption.Location = new System.Drawing.Point(15, 28);
            this.lblRateCaption.Name = "lblRateCaption";
            this.lblRateCaption.Text = "Tỷ giá USD/VND:";

            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRate.Location = new System.Drawing.Point(15, 48);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(255, 28);
            this.lblRate.Text = "--";

            this.lblOrdersCaption.AutoSize = true;
            this.lblOrdersCaption.Location = new System.Drawing.Point(15, 85);
            this.lblOrdersCaption.Name = "lblOrdersCaption";
            this.lblOrdersCaption.Text = "Đơn hàng mới (tích lũy):";

            this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOrders.Location = new System.Drawing.Point(15, 105);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(255, 28);
            this.lblOrders.Text = "0";

            this.lblLastSync.AutoSize = true;
            this.lblLastSync.Location = new System.Drawing.Point(15, 142);
            this.lblLastSync.Name = "lblLastSync";
            this.lblLastSync.Text = "Lần đồng bộ gần nhất: --";

            this.btnToggleSync.Location = new System.Drawing.Point(15, 168);
            this.btnToggleSync.Name = "btnToggleSync";
            this.btnToggleSync.Size = new System.Drawing.Size(255, 30);
            this.btnToggleSync.TabIndex = 0;
            this.btnToggleSync.Text = "Dừng đồng bộ";
            this.btnToggleSync.UseVisualStyleBackColor = true;
            this.btnToggleSync.Click += new System.EventHandler(this.btnToggleSync_Click);

            // dgvSync: nhật ký các lần đồng bộ (cột tạo bằng code trong Load)
            this.dgvSync.AllowUserToAddRows = false;
            this.dgvSync.AllowUserToDeleteRows = false;
            this.dgvSync.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSync.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSync.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSync.Location = new System.Drawing.Point(15, 210);
            this.dgvSync.Name = "dgvSync";
            this.dgvSync.ReadOnly = true;
            this.dgvSync.RowHeadersVisible = false;
            this.dgvSync.Size = new System.Drawing.Size(255, 195);
            this.dgvSync.TabIndex = 1;

            // frmAsyncReport
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.lblReportStatus);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnTestUi);
            this.Controls.Add(this.lblClickCount);
            this.Controls.Add(this.grpSync);
            this.Name = "frmAsyncReport";
            this.Text = "Báo cáo thống kê & đồng bộ dữ liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAsyncReport_FormClosing);
            this.Load += new System.EventHandler(this.frmAsyncReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.grpSync.ResumeLayout(false);
            this.grpSync.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSync)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.Label lblReportStatus;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnTestUi;
        private System.Windows.Forms.Label lblClickCount;
        private System.Windows.Forms.GroupBox grpSync;
        private System.Windows.Forms.Label lblRateCaption;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblOrdersCaption;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblLastSync;
        private System.Windows.Forms.Button btnToggleSync;
        private System.Windows.Forms.DataGridView dgvSync;
    }
}