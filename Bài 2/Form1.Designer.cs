namespace Frminventorymanager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslQty = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.picProductImage = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuSystem, this.mnuTools });
            this.menuStrip1.Name = "menuStrip1";

            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuOpen, this.mnuSaveReport, this.mnuSep1, this.mnuExit });
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Text = "System";

            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Text = "Open File";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);

            this.mnuSaveReport.Name = "mnuSaveReport";
            this.mnuSaveReport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveReport.Text = "Save Report";
            this.mnuSaveReport.Click += new System.EventHandler(this.mnuSaveReport_Click);

            this.mnuSep1.Name = "mnuSep1";

            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);

            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuImport, this.mnuExport });
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Text = "Tools";

            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Text = "Import CSV";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);

            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Text = "Export CSV";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);

            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsbOpen, this.tsbSave, this.tsSep1, this.tsbImport, this.tsbExport, this.tsSep2, this.tsbExit });
            this.toolStrip1.Name = "toolStrip1";

            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.tsbOpen.Image = System.Drawing.SystemIcons.Application.ToBitmap();
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Text = "Mở file";
            this.tsbOpen.Click += new System.EventHandler(this.mnuOpen_Click);          

            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.tsbSave.Image = System.Drawing.SystemIcons.Shield.ToBitmap();
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Text = "Lưu báo cáo";
            this.tsbSave.Click += new System.EventHandler(this.mnuSaveReport_Click);

            this.tsSep1.Name = "tsSep1";

            this.tsbImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.tsbImport.Image = System.Drawing.SystemIcons.Information.ToBitmap();
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Text = "Import CSV";
            this.tsbImport.Click += new System.EventHandler(this.mnuImport_Click);

            this.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.tsbExport.Image = System.Drawing.SystemIcons.Warning.ToBitmap();
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Text = "Export CSV";
            this.tsbExport.Click += new System.EventHandler(this.mnuExport_Click);

            this.tsSep2.Name = "tsSep2";

            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.tsbExit.Image = System.Drawing.SystemIcons.Error.ToBitmap();
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Text = "Thoát";
            this.tsbExit.Click += new System.EventHandler(this.mnuExit_Click);

            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tslTime, this.tslCount, this.tslQty, this.tslValue });
            this.statusStrip1.Name = "statusStrip1";

            this.tslTime.Name = "tslTime";
            this.tslTime.Spring = true;                                                
            this.tslTime.Text = "Thời gian:";
            this.tslTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.tslCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslCount.Name = "tslCount";
            this.tslCount.Text = "Số mặt hàng: 0";

            this.tslQty.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslQty.Name = "tslQty";
            this.tslQty.Text = "Tổng số lượng: 0";

            this.tslValue.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslValue.Name = "tslValue";
            this.tslValue.Text = "Tổng giá trị kho: 0 đ";

            this.grpInput.Controls.Add(this.lblId);
            this.grpInput.Controls.Add(this.txtId);
            this.grpInput.Controls.Add(this.lblName);
            this.grpInput.Controls.Add(this.txtName);
            this.grpInput.Controls.Add(this.lblCategory);
            this.grpInput.Controls.Add(this.cboCategory);
            this.grpInput.Controls.Add(this.lblPrice);
            this.grpInput.Controls.Add(this.txtPrice);
            this.grpInput.Controls.Add(this.lblQuantity);
            this.grpInput.Controls.Add(this.numQuantity);
            this.grpInput.Controls.Add(this.picProductImage);
            this.grpInput.Controls.Add(this.btnChooseImage);
            this.grpInput.Location = new System.Drawing.Point(15, 70);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(860, 195);
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Thông tin sản phẩm";

            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 33);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Mã sản phẩm:";

            this.txtId.Location = new System.Drawing.Point(120, 30);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 23);
            this.txtId.TabStop = false;

            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 78);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Tên sản phẩm:";

            this.txtName.Location = new System.Drawing.Point(120, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 0;

            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 123);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Loại:";

            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện", "Linh kiện" });
            this.cboCategory.Location = new System.Drawing.Point(120, 120);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 23);
            this.cboCategory.TabIndex = 1;

            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(345, 33);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Đơn giá:";

            this.txtPrice.Location = new System.Drawing.Point(430, 30);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(180, 23);
            this.txtPrice.TabIndex = 2;

            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(345, 78);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Text = "Số lượng:";

            this.numQuantity.Location = new System.Drawing.Point(430, 75);
            this.numQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(180, 23);
            this.numQuantity.TabIndex = 3;

            this.picProductImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductImage.Location = new System.Drawing.Point(640, 25);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(200, 120);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;   // Giữ đúng tỷ lệ ảnh
            this.picProductImage.TabStop = false;

            this.btnChooseImage.Location = new System.Drawing.Point(640, 152);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(200, 30);
            this.btnChooseImage.TabIndex = 4;
            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);

            this.btnAdd.Location = new System.Drawing.Point(15, 275);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(145, 275);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 34);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(275, 275);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location = new System.Drawing.Point(405, 275);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 34);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProducts.Location = new System.Drawing.Point(15, 320);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(860, 250);
            this.dgvProducts.TabIndex = 9;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);

            this.errorProvider.ContainerControl = this;

            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 620);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.toolStrip1);                          
            this.Controls.Add(this.menuStrip1);                         
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Name = "frmInventoryManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kho và xuất báo cáo tổng hợp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInventoryManager_FormClosing);
            this.Load += new System.EventHandler(this.frmInventoryManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveReport;
        private System.Windows.Forms.ToolStripSeparator mnuSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripSeparator tsSep2;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslTime;
        private System.Windows.Forms.ToolStripStatusLabel tslCount;
        private System.Windows.Forms.ToolStripStatusLabel tslQty;
        private System.Windows.Forms.ToolStripStatusLabel tslValue;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Timer tmrClock;
    }
}
