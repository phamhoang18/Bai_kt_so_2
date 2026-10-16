using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frminventorymanager
{
    public class Product
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; } = "";             

        public string ImageFileName
        {
            get { return string.IsNullOrEmpty(ImagePath) ? "" : Path.GetFileName(ImagePath); }
        }
    }
    public partial class Form1 : Form
    {
        private const char Delimiter = ';';                     

        private readonly BindingList<Product> products = new BindingList<Product>();
        private readonly BindingSource bsProducts = new BindingSource();
        private int nextId = 1;
        private string currentImagePath = "";                   
        public Form1()
        {
            InitializeComponent();
        }
        private void frmInventoryManager_Load(object sender, EventArgs e)
        {
            InitGrid();
            bsProducts.DataSource = products;
            dgvProducts.DataSource = bsProducts;

            products.Add(new Product { Id = PeekId(), Name = "iPhone 15", Category = "Điện thoại", Price = 22000000, Quantity = 10 });
            nextId++;
            products.Add(new Product { Id = PeekId(), Name = "Dell Inspiron 14", Category = "Laptop", Price = 15500000, Quantity = 5 });
            nextId++;

            ClearForm();
            UpdateStatus();
            UpdateClock();
        }

        private void InitGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã SP", DataPropertyName = "Id", FillWeight = 10 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sản phẩm", DataPropertyName = "Name", FillWeight = 28 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại", DataPropertyName = "Category", FillWeight = 16 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá (VNĐ)",
                DataPropertyName = "Price",
                FillWeight = 16,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "Quantity",
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tệp ảnh", DataPropertyName = "ImageFileName", FillWeight = 20 });
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            tslTime.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void UpdateStatus()
        {
            int totalQty = products.Sum(p => p.Quantity);
            decimal totalValue = products.Sum(p => p.Price * p.Quantity);

            tslCount.Text = "Số mặt hàng: " + products.Count;
            tslQty.Text = "Tổng số lượng: " + totalQty.ToString("N0");
            tslValue.Text = "Tổng giá trị kho: " + totalValue.ToString("N0") + " đ";
        }
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Tệp hình ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    ShowImage(currentImagePath);
                }
            }
        }
        private void ShowImage(string path)
        {
            if (picProductImage.Image != null)
            {
                picProductImage.Image.Dispose();
                picProductImage.Image = null;
            }

            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;

            try
            {
                using (Image temp = Image.FromFile(path))
                {
                    picProductImage.Image = new Bitmap(temp);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal price)) return;

            products.Add(new Product
            {
                Id = txtId.Text,
                Name = txtName.Text.Trim(),
                Category = cboCategory.Text,
                Price = price,
                Quantity = (int)numQuantity.Value,
                ImagePath = currentImagePath                    
            });
            nextId++;

            ClearForm();
            UpdateStatus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Hãy chọn một dòng trong danh sách để cập nhật!", "Chưa chọn dòng",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(out decimal price)) return;

            p.Name = txtName.Text.Trim();
            p.Category = cboCategory.Text;
            p.Price = price;
            p.Quantity = (int)numQuantity.Value;
            p.ImagePath = currentImagePath;

            bsProducts.ResetItem(products.IndexOf(p));         
            UpdateStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Hãy chọn một dòng cần xóa!", "Chưa chọn dòng",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xóa sản phẩm \"" + p.Name + "\"?", "Xác nhận xóa",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                products.Remove(p);
                ClearForm();
                UpdateStatus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;

            txtId.Text = p.Id;
            txtName.Text = p.Name;
            cboCategory.SelectedItem = p.Category;
            txtPrice.Text = p.Price.ToString();
            numQuantity.Value = p.Quantity;
            currentImagePath = p.ImagePath;
            ShowImage(currentImagePath);
            ClearErrors();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            ImportCsv();
        }

        private void mnuImport_Click(object sender, EventArgs e)
        {
            ImportCsv();
        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }

        private void mnuSaveReport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu báo cáo tổng hợp";
                sfd.Filter = "Tệp văn bản (*.txt)|*.txt";
                sfd.FileName = "BaoCaoKho_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                List<string> lines = new List<string>();
                lines.Add("BÁO CÁO TỔNG HỢP KHO HÀNG");
                lines.Add("Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                lines.Add("Số mặt hàng: " + products.Count);
                lines.Add("Tổng số lượng: " + products.Sum(p => p.Quantity).ToString("N0"));
                lines.Add("Tổng giá trị kho: " + products.Sum(p => p.Price * p.Quantity).ToString("N0") + " đ");
                lines.Add(new string('-', 60));
                foreach (Product p in products)
                {
                    lines.Add(p.Id + " | " + p.Name + " | " + p.Category + " | " +
                              p.Price.ToString("N0") + " x " + p.Quantity);
                }

                try
                {
                    File.WriteAllLines(sfd.FileName, lines, new UTF8Encoding(true));
                    MessageBox.Show("Đã lưu báo cáo tại:\n" + sfd.FileName, "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventoryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;                                 
            }
        }

        private void ExportCsv()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất dữ liệu kho ra CSV";
                sfd.Filter = "Tệp CSV (*.csv)|*.csv";
                sfd.FileName = "Kho_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                List<string> lines = new List<string>();
                lines.Add(string.Join(Delimiter.ToString(), "Id", "Name", "Category", "Price", "Quantity", "ImagePath"));

                foreach (Product p in products)
                {
                    lines.Add(string.Join(Delimiter.ToString(),
                        CsvEscape(p.Id),
                        CsvEscape(p.Name),
                        CsvEscape(p.Category),
                        p.Price.ToString(CultureInfo.InvariantCulture),     
                        p.Quantity.ToString(),
                        CsvEscape(p.ImagePath)));
                }

                try
                {
                    File.WriteAllLines(sfd.FileName, lines, new UTF8Encoding(true));
                    MessageBox.Show("Đã xuất " + products.Count + " sản phẩm ra file:\n" + sfd.FileName,
                                    "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImportCsv()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file CSV để nhập";
                ofd.Filter = "Tệp CSV (*.csv)|*.csv|Tất cả tệp (*.*)|*.*";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                List<Product> loaded = new List<Product>();
             x`   int skipped = 0;

                try
                {
                    string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);

                    for (int i = 1; i < lines.Length; i++)      
                    {
                        if (string.IsNullOrWhiteSpace(lines[i])) continue;

                        List<string> f = ParseCsvLine(lines[i]);

                        if (f.Count < 5 ||
                            !decimal.TryParse(f[3], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price) ||
                            !int.TryParse(f[4], out int qty))
                        {
                            skipped++;                         
                            continue;
                        }

                        loaded.Add(new Product
                        {
                            Id = f[0],
                            Name = f[1],
                            Category = f[2],
                            Price = price,
                            Quantity = qty,
                            ImagePath = f.Count > 5 ? f[5] : ""
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (products.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Dữ liệu hiện tại sẽ bị thay thế bằng dữ liệu trong file. Tiếp tục?",
                                                           "Xác nhận nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.No) return;
                }

                products.Clear();
                foreach (Product p in loaded)
                    products.Add(p);
                nextId = 1;
                while (products.Any(p => p.Id == PeekId()))
                    nextId++;

                ClearForm();
                UpdateStatus();

                MessageBox.Show("Đã nhập " + loaded.Count + " sản phẩm." +
                                (skipped > 0 ? "\nBỏ qua " + skipped + " dòng sai định dạng." : ""),
                                "Nhập CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static string CsvEscape(string value)
        {
            if (value == null) return "";
            if (value.IndexOfAny(new char[] { Delimiter, '"', '\n', '\r' }) >= 0)
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        private static List<string> ParseCsvLine(string line)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"') { sb.Append('"'); i++; }   // "" -> "
                        else inQuotes = false;
                    }
                    else sb.Append(c);
                }
                else if (c == '"') inQuotes = true;
                else if (c == Delimiter) { result.Add(sb.ToString()); sb.Clear(); }
                else sb.Append(c);
            }

            result.Add(sb.ToString());
            return result;
        }

        // ===== Hàm hỗ trợ =====
        private string PeekId()
        {
            return "SP" + nextId.ToString("000");
        }

        private Product GetSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0) return null;
            return dgvProducts.SelectedRows[0].DataBoundItem as Product;
        }

        private bool ValidateInput(out decimal price)
        {
            ClearErrors();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }
            if (cboCategory.SelectedIndex < 0)
            {
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại sản phẩm!");
                isValid = false;
            }
            if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price < 0)
            {
                errorProvider.SetError(txtPrice, "Đơn giá phải là số hợp lệ và không nhỏ hơn 0!");
                isValid = false;
            }
            return isValid;
        }

        private void ClearErrors()
        {
            errorProvider.SetError(txtName, "");
            errorProvider.SetError(cboCategory, "");
            errorProvider.SetError(txtPrice, "");
        }

        private void ClearForm()
        {
            ClearErrors();
            txtId.Text = PeekId();
            txtName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            currentImagePath = "";
            ShowImage("");
            dgvProducts.ClearSelection();
            txtName.Focus();
        }
    }
}
