using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bai03
{
    public partial class Form1 : Form
    {
        private readonly List<Product> _all = new List<Product>();                 
        private readonly BindingList<Product> _view = new BindingList<Product>();   
        private readonly BindingSource _bs = new BindingSource();
        private string _imagePath = string.Empty;
        private bool _suspendSelect;
        private int _seq;

        public Form1()
        {
            InitializeComponent();

            // Data Binding: DataGridView <- BindingSource <- BindingList<Product>
            _bs.DataSource = _view;
            dgvProducts.DataSource = _bs;

            LoadCategories();
            LoadSampleData();
            ApplyFilter();
        }

        // =====================================================================
        //  DỮ LIỆU
        // =====================================================================
        private void LoadCategories()
        {
            var cats = new List<Category>
            {
                new Category { Id = 1, Name = "Điện thoại" },
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Phụ kiện" }
            };
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = cats;
        }

        private void LoadSampleData()
        {
            _all.Add(new Product { Id = "SP001", Name = "iPhone 15", CategoryId = 1, CategoryName = "Điện thoại", UnitPrice = 22000000m, Quantity = 10 });
            _all.Add(new Product { Id = "SP002", Name = "MacBook Air M2", CategoryId = 2, CategoryName = "Laptop", UnitPrice = 28000000m, Quantity = 5 });
            _all.Add(new Product { Id = "SP003", Name = "Chuột Logitech MX", CategoryId = 3, CategoryName = "Phụ kiện", UnitPrice = 1500000m, Quantity = 30 });
            _seq = 3;
        }

        // Lọc theo tên rồi nạp lại BindingList (Live search)
        private void ApplyFilter()
        {
            _suspendSelect = true;
            try
            {
                string kw = txtSearch.Text.Trim();
                IEnumerable<Product> q = _all;
                if (kw.Length > 0)
                    q = _all.Where(p => p.Name.IndexOf(kw, StringComparison.CurrentCultureIgnoreCase) >= 0);

                var list = q.ToList();
                _view.RaiseListChangedEvents = false;
                _view.Clear();
                foreach (var p in list) _view.Add(p);
                _view.RaiseListChangedEvents = true;
                _view.ResetBindings();
            }
            finally
            {
                _suspendSelect = false;
            }
            lblTotal.Text = "Tổng số sản phẩm: " + _all.Count;
        }

        private string NextId()
        {
            string id;
            do { _seq++; id = "SP" + _seq.ToString("000"); }
            while (_all.Any(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase)));
            return id;
        }

        // =====================================================================
        //  VALIDATION
        // =====================================================================
        private bool ValidateInput(out decimal price, out int qty)
        {
            errorProvider.Clear();
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống");
                ok = false;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out price) || price <= 0)
            {
                errorProvider.SetError(txtUnitPrice, "Đơn giá phải là số lớn hơn 0");
                ok = false;
            }

            if (!int.TryParse(txtQuantity.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out qty) || qty < 0)
            {
                errorProvider.SetError(txtQuantity, "Số lượng phải là số nguyên ≥ 0");
                ok = false;
            }
            return ok;
        }

        // =====================================================================
        //  SỰ KIỆN / CHỨC NĂNG
        // =====================================================================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            decimal price; int qty;
            if (!ValidateInput(out price, out qty)) return;

            string id = txtProductId.Text.Trim();
            if (id.Length == 0)
                id = NextId();
            else if (_all.Any(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cat = (Category)cboCategory.SelectedItem;
            _all.Add(new Product
            {
                Id = id,
                Name = txtProductName.Text.Trim(),
                CategoryId = cat.Id,
                CategoryName = cat.Name,
                UnitPrice = price,
                Quantity = qty,
                ImagePath = _imagePath
            });

            ApplyFilter();
            ClearForm();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var p = dgvProducts.CurrentRow == null ? null : dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trên bảng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal price; int qty;
            if (!ValidateInput(out price, out qty)) return;

            string id = txtProductId.Text.Trim();
            if (id.Length == 0) id = p.Id;
            if (_all.Any(x => !ReferenceEquals(x, p) && x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cat = (Category)cboCategory.SelectedItem;
            p.Id = id;
            p.Name = txtProductName.Text.Trim();
            p.CategoryId = cat.Id;
            p.CategoryName = cat.Name;
            p.UnitPrice = price;
            p.Quantity = qty;
            p.ImagePath = _imagePath;

            ApplyFilter();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var p = dgvProducts.CurrentRow == null ? null : dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm \"" + p.Name + "\"?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                _all.Remove(p);
                ApplyFilter();
                ClearForm();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Click chọn dòng => nạp ngược lên các ô nhập liệu
        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (_suspendSelect) return;
            var p = dgvProducts.CurrentRow == null ? null : dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p == null) return;

            errorProvider.Clear();
            txtProductId.Text = p.Id;
            txtProductName.Text = p.Name;
            cboCategory.SelectedValue = p.CategoryId;
            txtUnitPrice.Text = p.UnitPrice.ToString("0.##", CultureInfo.InvariantCulture);
            txtQuantity.Text = p.Quantity.ToString(CultureInfo.InvariantCulture);
            _imagePath = p.ImagePath ?? string.Empty;
            ShowImage(_imagePath);
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Tệp ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Tất cả tệp|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _imagePath = ofd.FileName;
                    ShowImage(_imagePath);
                }
            }
        }

        private void ShowImage(string path)
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;

            try
            {
                // Đọc qua stream rồi copy sang Bitmap để không khóa file trên đĩa
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var img = Image.FromStream(fs))
                {
                    picAvatar.Image = new Bitmap(img);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            errorProvider.Clear();
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            _imagePath = string.Empty;
            ShowImage(null);
            txtProductName.Focus();
        }

        // =====================================================================
        //  XUẤT CSV (dùng chung cho menu File → Export CSV và nút "Xuất CSV")
        // =====================================================================
        private void Export_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách sản phẩm";
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "products.csv";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var sb = new StringBuilder();
                sb.AppendLine("Mã SP,Tên SP,Danh mục,Đơn giá,Số lượng");
                foreach (var p in _all)
                {
                    sb.AppendLine(string.Join(",",
                        Csv(p.Id),
                        Csv(p.Name),
                        Csv(p.CategoryName),
                        p.UnitPrice.ToString("0.##", CultureInfo.InvariantCulture),
                        p.Quantity.ToString(CultureInfo.InvariantCulture)));
                }

                try
                {
                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true)); // UTF-8 BOM để Excel đọc đúng tiếng Việt
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string Csv(string s)
        {
            if (s == null) return string.Empty;
            if (s.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0)
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}