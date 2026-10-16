using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bai3_MdiSupermarket
{
    // Model sản phẩm của form danh mục (bản rút gọn từ Bài 1 và Bài 2)
    public class Product
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public partial class frmProductCatalog : Form
    {
        private readonly BindingList<Product> products = new BindingList<Product>();
        private readonly BindingSource bsProducts = new BindingSource();
        private int nextId = 1;

        public frmProductCatalog()
        {
            InitializeComponent();
        }

        private void frmProductCatalog_Load(object sender, EventArgs e)
        {
            InitGrid();
            bsProducts.DataSource = products;
            dgvProducts.DataSource = bsProducts;

            products.Add(new Product { Id = NewId(), Name = "Sữa tươi 1L", Category = "Đồ uống", Price = 32000, Quantity = 120 });
            products.Add(new Product { Id = NewId(), Name = "Mì gói", Category = "Thực phẩm", Price = 4500, Quantity = 500 });
            ClearForm();
        }

        private void InitGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã SP", DataPropertyName = "Id", FillWeight = 12 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sản phẩm", DataPropertyName = "Name", FillWeight = 36 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nhóm hàng", DataPropertyName = "Category", FillWeight = 20 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá (VNĐ)",
                DataPropertyName = "Price",
                FillWeight = 20,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tồn kho",
                DataPropertyName = "Quantity",
                FillWeight = 12,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        // Sinh mã và tăng bộ đếm
        private string NewId()
        {
            return "SP" + (nextId++).ToString("000");
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;

            txtName.Text = p.Name;
            cboCategory.SelectedItem = p.Category;
            txtPrice.Text = p.Price.ToString();
            numQuantity.Value = p.Quantity;
            ClearErrors();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal price)) return;

            products.Add(new Product
            {
                Id = NewId(),
                Name = txtName.Text.Trim(),
                Category = cboCategory.Text,
                Price = price,
                Quantity = (int)numQuantity.Value
            });
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Hãy chọn một dòng để cập nhật!", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput(out decimal price)) return;

            p.Name = txtName.Text.Trim();
            p.Category = cboCategory.Text;
            p.Price = price;
            p.Quantity = (int)numQuantity.Value;
            bsProducts.ResetItem(products.IndexOf(p));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Hãy chọn một dòng cần xóa!", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xóa sản phẩm \"" + p.Name + "\"?", "Xác nhận xóa",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                products.Remove(p);
                ClearForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
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
                errorProvider.SetError(cboCategory, "Vui lòng chọn nhóm hàng!");
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
            txtName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            dgvProducts.ClearSelection();
            txtName.Focus();
        }
    }
}