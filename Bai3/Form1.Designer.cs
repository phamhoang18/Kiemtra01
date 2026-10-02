using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace bai03
{
    partial class Form1
    {
        private IContainer components = null;

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
            this.components = new Container();

            //Khởi tạo control 
            this.menuStrip = new MenuStrip();
            this.mnuFile = new ToolStripMenuItem();
            this.mnuExport = new ToolStripMenuItem();
            this.mnuSeparator = new ToolStripSeparator();
            this.mnuExit = new ToolStripMenuItem();

            this.statusStrip = new StatusStrip();
            this.lblTotal = new ToolStripStatusLabel();

            this.errorProvider = new ErrorProvider(this.components);

            this.tableMain = new TableLayoutPanel();

            this.grpInput = new GroupBox();
            this.tblInput = new TableLayoutPanel();
            this.lblId = new Label();
            this.lblName = new Label();
            this.lblCategory = new Label();
            this.lblPrice = new Label();
            this.lblQty = new Label();
            this.lblImage = new Label();
            this.txtProductId = new TextBox();
            this.txtProductName = new TextBox();
            this.cboCategory = new ComboBox();
            this.txtUnitPrice = new TextBox();
            this.txtQuantity = new TextBox();
            this.picAvatar = new PictureBox();
            this.btnChooseImage = new Button();
            this.flowButtons = new FlowLayoutPanel();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            this.btnExport = new Button();

            this.tblGrid = new TableLayoutPanel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.dgvProducts = new DataGridView();
            this.colId = new DataGridViewTextBoxColumn();
            this.colName = new DataGridViewTextBoxColumn();
            this.colCategory = new DataGridViewTextBoxColumn();
            this.colPrice = new DataGridViewTextBoxColumn();
            this.colQty = new DataGridViewTextBoxColumn();

            ((ISupportInitialize)(this.errorProvider)).BeginInit();
            ((ISupportInitialize)(this.picAvatar)).BeginInit();
            ((ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableMain.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.tblInput.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.tblGrid.SuspendLayout();
            this.SuspendLayout();

            // errorProvider 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

            // menuStrip 
            this.menuStrip.Items.AddRange(new ToolStripItem[] { this.mnuFile });
            this.menuStrip.Name = "menuStrip";

            this.mnuFile.DropDownItems.AddRange(new ToolStripItem[] { this.mnuExport, this.mnuSeparator, this.mnuExit });
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Text = "&File";

            this.mnuExport.Name = "mnuExport";
            this.mnuExport.ShortcutKeys = Keys.Control | Keys.E;
            this.mnuExport.Text = "Export CSV";
            this.mnuExport.Click += new System.EventHandler(this.Export_Click);

            this.mnuSeparator.Name = "mnuSeparator";

            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = Keys.Control | Keys.X;
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.MnuExit_Click);

            // statusStrip 
            this.statusStrip.Items.AddRange(new ToolStripItem[] { this.lblTotal });
            this.statusStrip.Name = "statusStrip";

            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Tổng số sản phẩm: 0";

            // tableMain: 35% | 65% 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            this.tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            this.tableMain.RowCount = 1;
            this.tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.grpInput, 0, 0);
            this.tableMain.Controls.Add(this.tblGrid, 1, 0);
            this.tableMain.Dock = DockStyle.Fill;
            this.tableMain.Name = "tableMain";
            this.tableMain.Padding = new Padding(8);

            // grpInput
            this.grpInput.Controls.Add(this.tblInput);
            this.grpInput.Dock = DockStyle.Fill;
            this.grpInput.Name = "grpInput";
            this.grpInput.Padding = new Padding(8);
            this.grpInput.Text = "Thông tin sản phẩm";

            // tblInput 
            this.tblInput.ColumnCount = 2;
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            this.tblInput.RowCount = 8;
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblInput.Controls.Add(this.lblId, 0, 0);
            this.tblInput.Controls.Add(this.txtProductId, 1, 0);
            this.tblInput.Controls.Add(this.lblName, 0, 1);
            this.tblInput.Controls.Add(this.txtProductName, 1, 1);
            this.tblInput.Controls.Add(this.lblCategory, 0, 2);
            this.tblInput.Controls.Add(this.cboCategory, 1, 2);
            this.tblInput.Controls.Add(this.lblPrice, 0, 3);
            this.tblInput.Controls.Add(this.txtUnitPrice, 1, 3);
            this.tblInput.Controls.Add(this.lblQty, 0, 4);
            this.tblInput.Controls.Add(this.txtQuantity, 1, 4);
            this.tblInput.Controls.Add(this.lblImage, 0, 5);
            this.tblInput.Controls.Add(this.picAvatar, 1, 5);
            this.tblInput.Controls.Add(this.btnChooseImage, 1, 6);
            this.tblInput.Controls.Add(this.flowButtons, 0, 7);
            this.tblInput.SetColumnSpan(this.flowButtons, 2);
            this.tblInput.Dock = DockStyle.Fill;
            this.tblInput.Name = "tblInput";

            //Labels 
            ConfigLabel(this.lblId, "lblId", "Mã SP:");
            ConfigLabel(this.lblName, "lblName", "Tên SP:");
            ConfigLabel(this.lblCategory, "lblCategory", "Danh mục:");
            ConfigLabel(this.lblPrice, "lblPrice", "Đơn giá:");
            ConfigLabel(this.lblQty, "lblQty", "Số lượng:");
            this.lblImage.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.lblImage.AutoSize = true;
            this.lblImage.Margin = new Padding(3, 8, 3, 3);
            this.lblImage.Name = "lblImage";
            this.lblImage.Text = "Ảnh:";

            //TextBox / ComboBox
            ConfigTextBox(this.txtProductId, "txtProductId");
            ConfigTextBox(this.txtProductName, "txtProductName");
            ConfigTextBox(this.txtUnitPrice, "txtUnitPrice");
            ConfigTextBox(this.txtQuantity, "txtQuantity");

            this.cboCategory.Dock = DockStyle.Fill;
            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategory.Margin = new Padding(3, 6, 3, 6);
            this.cboCategory.Name = "cboCategory";

            //picAvatar
            this.picAvatar.BorderStyle = BorderStyle.FixedSingle;
            this.picAvatar.Dock = DockStyle.Fill;
            this.picAvatar.MinimumSize = new Size(80, 80);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            this.picAvatar.TabStop = false;

            // btnChooseImage
            this.btnChooseImage.Anchor = AnchorStyles.Left;
            this.btnChooseImage.AutoSize = true;
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Text = "Chọn ảnh...";
            this.btnChooseImage.Click += new System.EventHandler(this.BtnChooseImage_Click);

            //flowButtons
            this.flowButtons.AutoSize = true;
            this.flowButtons.Controls.Add(this.btnAdd);
            this.flowButtons.Controls.Add(this.btnUpdate);
            this.flowButtons.Controls.Add(this.btnDelete);
            this.flowButtons.Controls.Add(this.btnClear);
            this.flowButtons.Controls.Add(this.btnExport);
            this.flowButtons.Dock = DockStyle.Fill;
            this.flowButtons.Name = "flowButtons";

            ConfigButton(this.btnAdd, "btnAdd", "Thêm mới");
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            ConfigButton(this.btnUpdate, "btnUpdate", "Cập nhật");
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            ConfigButton(this.btnDelete, "btnDelete", "Xóa");
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            ConfigButton(this.btnClear, "btnClear", "Làm mới");
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            ConfigButton(this.btnExport, "btnExport", "Xuất CSV");
            this.btnExport.Click += new System.EventHandler(this.Export_Click);

            //tblGrid
            this.tblGrid.ColumnCount = 2;
            this.tblGrid.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.tblGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tblGrid.RowCount = 2;
            this.tblGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tblGrid.Controls.Add(this.lblSearch, 0, 0);
            this.tblGrid.Controls.Add(this.txtSearch, 1, 0);
            this.tblGrid.Controls.Add(this.dgvProducts, 0, 1);
            this.tblGrid.SetColumnSpan(this.dgvProducts, 2);
            this.tblGrid.Dock = DockStyle.Fill;
            this.tblGrid.Name = "tblGrid";

            this.lblSearch.Anchor = AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Margin = new Padding(3, 8, 3, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Tìm theo tên:";

            this.txtSearch.Dock = DockStyle.Fill;
            this.txtSearch.Margin = new Padding(3, 6, 3, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            //dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = SystemColors.Window;
            this.dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                this.colId, this.colName, this.colCategory, this.colPrice, this.colQty });
            this.dgvProducts.Dock = DockStyle.Fill;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.DgvProducts_SelectionChanged);

            this.colId.DataPropertyName = "Id";
            this.colId.FillWeight = 15F;
            this.colId.HeaderText = "Mã SP";
            this.colId.Name = "colId";

            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 35F;
            this.colName.HeaderText = "Tên SP";
            this.colName.Name = "colName";

            this.colCategory.DataPropertyName = "CategoryName";
            this.colCategory.FillWeight = 17F;
            this.colCategory.HeaderText = "Danh Mục";
            this.colCategory.Name = "colCategory";

            var priceStyle = new DataGridViewCellStyle();
            priceStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            priceStyle.Format = "N0";
            priceStyle.FormatProvider = CultureInfo.InvariantCulture;   // hiển thị 25,000,000
            this.colPrice.DataPropertyName = "UnitPrice";
            this.colPrice.DefaultCellStyle = priceStyle;
            this.colPrice.FillWeight = 20F;
            this.colPrice.HeaderText = "Đơn Giá (VNĐ)";
            this.colPrice.Name = "colPrice";

            var qtyStyle = new DataGridViewCellStyle();
            qtyStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colQty.DataPropertyName = "Quantity";
            this.colQty.DefaultCellStyle = qtyStyle;
            this.colQty.FillWeight = 13F;
            this.colQty.HeaderText = "Số Lượng";
            this.colQty.Name = "colQty";

            // Form1
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1084, 611);
            this.Controls.Add(this.tableMain);    // Fill: add trước
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new Font("Segoe UI", 9.5F);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new Size(850, 520);
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "TechMart Product Manager";

            ((ISupportInitialize)(this.errorProvider)).EndInit();
            ((ISupportInitialize)(this.picAvatar)).EndInit();
            ((ISupportInitialize)(this.dgvProducts)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableMain.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.tblInput.ResumeLayout(false);
            this.tblInput.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            this.tblGrid.ResumeLayout(false);
            this.tblGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Hàm hỗ trợ cấu hình control
        private static void ConfigLabel(Label lbl, string name, string text)
        {
            lbl.Anchor = AnchorStyles.Left;
            lbl.AutoSize = true;
            lbl.Margin = new Padding(3, 8, 3, 3);
            lbl.Name = name;
            lbl.Text = text;
        }

        private static void ConfigTextBox(TextBox txt, string name)
        {
            txt.Dock = DockStyle.Fill;
            txt.Margin = new Padding(3, 6, 3, 6);
            txt.Name = name;
        }

        private static void ConfigButton(Button btn, string name, string text)
        {
            btn.Margin = new Padding(3);
            btn.Name = name;
            btn.Size = new Size(95, 32);
            btn.Text = text;
        }

        #endregion

        //Khai báo control 
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuExport;
        private ToolStripSeparator mnuSeparator;
        private ToolStripMenuItem mnuExit;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTotal;
        private ErrorProvider errorProvider;

        private TableLayoutPanel tableMain;
        private GroupBox grpInput;
        private TableLayoutPanel tblInput;
        private Label lblId, lblName, lblCategory, lblPrice, lblQty, lblImage;
        private TextBox txtProductId, txtProductName, txtUnitPrice, txtQuantity;
        private ComboBox cboCategory;
        private PictureBox picAvatar;
        private Button btnChooseImage, btnAdd, btnUpdate, btnDelete, btnClear, btnExport;
        private FlowLayoutPanel flowButtons;

        private TableLayoutPanel tblGrid;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colId, colName, colCategory, colPrice, colQty;
    }
}
