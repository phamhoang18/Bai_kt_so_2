using System.ComponentModel;

namespace Frmdevicemanager
{
    public class Device
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public partial class Form1 : Form
    {
        private readonly BindingList<Device> devices = new BindingList<Device>();
        private readonly BindingSource bsDevices = new BindingSource();
        private int nextId = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void frmDeviceManager_Load(object sender, EventArgs e)
        {
            InitGrid();                                        
            bsDevices.DataSource = devices;                     
            dgvDevices.DataSource = bsDevices;                  
            SeedData();
            ClearForm();
        }

        private void InitGrid()
        {
            dgvDevices.AutoGenerateColumns = false;            
            dgvDevices.Columns.Clear();
            dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;   

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Mã TB",
                DataPropertyName = "Id",
                FillWeight = 12
            });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Tên thiết bị",
                DataPropertyName = "Name",
                FillWeight = 34
            });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Loại",
                DataPropertyName = "Category",
                FillWeight = 20
            });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Đơn giá (VNĐ)",
                DataPropertyName = "Price",
                FillWeight = 20,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",                             
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "Tồn kho",
                DataPropertyName = "Quantity",
                FillWeight = 14,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void SeedData()
        {
            devices.Add(new Device { Id = PeekId(), Name = "iPhone 15", Category = "Điện thoại", Price = 22000000, Quantity = 10 });
            nextId++;
            devices.Add(new Device { Id = PeekId(), Name = "Dell Inspiron 14", Category = "Laptop", Price = 15500000, Quantity = 5 });
            nextId++;
            devices.Add(new Device { Id = PeekId(), Name = "Chuột Logitech M331", Category = "Phụ kiện", Price = 350000, Quantity = 40 });
            nextId++;
        }

        private string PeekId()
        {
            return "TB" + nextId.ToString("000");
        }

        private void dgvDevices_SelectionChanged(object sender, EventArgs e)
        {
            Device d = GetSelectedDevice();
            if (d == null) return;                             

            txtDeviceId.Text = d.Id;
            txtDeviceName.Text = d.Name;
            cboCategory.SelectedItem = d.Category;             
            txtPrice.Text = d.Price.ToString();
            numQuantity.Value = d.Quantity;
            ClearErrors();                                       
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal price)) return;

            Device d = new Device
            {
                Id = txtDeviceId.Text,
                Name = txtDeviceName.Text.Trim(),
                Category = cboCategory.Text,
                Price = price,
                Quantity = (int)numQuantity.Value
            };

            devices.Add(d);                                     
            nextId++;
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Device d = GetSelectedDevice();
            if (d == null)
            {
                MessageBox.Show("Hãy chọn một dòng trong danh sách để cập nhật!", "Chưa chọn dòng",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(out decimal price)) return;

            d.Name = txtDeviceName.Text.Trim();
            d.Category = cboCategory.Text;
            d.Price = price;
            d.Quantity = (int)numQuantity.Value;

            bsDevices.ResetItem(devices.IndexOf(d));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Device d = GetSelectedDevice();
            if (d == null)
            {
                MessageBox.Show("Hãy chọn một dòng cần xóa!", "Chưa chọn dòng",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa thiết bị \"" + d.Name + "\" không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                devices.Remove(d);                               
                ClearForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private Device GetSelectedDevice()
        {
            if (dgvDevices.SelectedRows.Count == 0) return null;
            return dgvDevices.SelectedRows[0].DataBoundItem as Device;   
        }

        private bool ValidateInput(out decimal price)
        {
            ClearErrors();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider.SetError(txtDeviceName, "Tên thiết bị không được để trống!");
                isValid = false;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại thiết bị!");
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
            errorProvider.SetError(txtDeviceName, "");
            errorProvider.SetError(cboCategory, "");
            errorProvider.SetError(txtPrice, "");
        }

        private void ClearForm()
        {
            ClearErrors();
            txtDeviceId.Text = PeekId();
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            dgvDevices.ClearSelection();                         
            txtDeviceName.Focus();
        }
    }
}
