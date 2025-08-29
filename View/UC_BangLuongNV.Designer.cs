namespace QUAN_LY_NHAN_VIEN.View
{
    partial class UC_BangLuongNV
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTimBLNV = new Guna.UI2.WinForms.Guna2Button();
            this.textBoxTenNV_BLNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.comBoxPhongBanBLNV = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dateThangLuongBLNV = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaNV_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNV_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongBan_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuVu_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongCoBan_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhuCap_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thuong_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhauTru_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThucLanh_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThangLam_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu_BLNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lableTongLuongBLNV = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSuaBLNV = new Guna.UI2.WinForms.Guna2Button();
            this.buttonXoaBLNV = new Guna.UI2.WinForms.Guna2Button();
            this.buttonXuatExcelBLNV = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 409F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 456F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTimBLNV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTenNV_BLNV, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comBoxPhongBanBLNV, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateThangLuongBLNV, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lableTongLuongBLNV, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1784, 728);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 6);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1778, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "BẢNG LƯƠNG NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTimBLNV
            // 
            this.buttonTimBLNV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonTimBLNV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonTimBLNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonTimBLNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonTimBLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTimBLNV.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonTimBLNV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTimBLNV.ForeColor = System.Drawing.Color.Black;
            this.buttonTimBLNV.Location = new System.Drawing.Point(3, 88);
            this.buttonTimBLNV.Name = "buttonTimBLNV";
            this.buttonTimBLNV.Size = new System.Drawing.Size(136, 55);
            this.buttonTimBLNV.TabIndex = 1;
            this.buttonTimBLNV.Text = "Tìm";
            // 
            // textBoxTenNV_BLNV
            // 
            this.textBoxTenNV_BLNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTenNV_BLNV.DefaultText = "";
            this.textBoxTenNV_BLNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxTenNV_BLNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxTenNV_BLNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTenNV_BLNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTenNV_BLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTenNV_BLNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTenNV_BLNV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenNV_BLNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTenNV_BLNV.Location = new System.Drawing.Point(147, 91);
            this.textBoxTenNV_BLNV.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxTenNV_BLNV.Name = "textBoxTenNV_BLNV";
            this.textBoxTenNV_BLNV.PlaceholderText = "Nhập mã nhân viên";
            this.textBoxTenNV_BLNV.SelectedText = "";
            this.textBoxTenNV_BLNV.Size = new System.Drawing.Size(399, 49);
            this.textBoxTenNV_BLNV.TabIndex = 2;
            // 
            // comBoxPhongBanBLNV
            // 
            this.comBoxPhongBanBLNV.BackColor = System.Drawing.Color.Transparent;
            this.comBoxPhongBanBLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comBoxPhongBanBLNV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comBoxPhongBanBLNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxPhongBanBLNV.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comBoxPhongBanBLNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comBoxPhongBanBLNV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comBoxPhongBanBLNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comBoxPhongBanBLNV.ItemHeight = 30;
            this.comBoxPhongBanBLNV.Location = new System.Drawing.Point(845, 88);
            this.comBoxPhongBanBLNV.Name = "comBoxPhongBanBLNV";
            this.comBoxPhongBanBLNV.Size = new System.Drawing.Size(250, 36);
            this.comBoxPhongBanBLNV.TabIndex = 4;
            // 
            // dateThangLuongBLNV
            // 
            this.dateThangLuongBLNV.Checked = true;
            this.dateThangLuongBLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateThangLuongBLNV.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dateThangLuongBLNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateThangLuongBLNV.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateThangLuongBLNV.Location = new System.Drawing.Point(554, 88);
            this.dateThangLuongBLNV.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateThangLuongBLNV.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateThangLuongBLNV.Name = "dateThangLuongBLNV";
            this.dateThangLuongBLNV.Size = new System.Drawing.Size(285, 55);
            this.dateThangLuongBLNV.TabIndex = 5;
            this.dateThangLuongBLNV.Value = new System.DateTime(2025, 8, 28, 10, 14, 34, 989);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV_BLNV,
            this.HoTenNV_BLNV,
            this.PhongBan_BLNV,
            this.ChuVu_BLNV,
            this.LuongCoBan_BLNV,
            this.PhuCap_BLNV,
            this.Thuong_BLNV,
            this.KhauTru_BLNV,
            this.ThucLanh_BLNV,
            this.ThangLam_BLNV,
            this.GhiChu_BLNV});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 7);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1778, 320);
            this.dataGridView1.TabIndex = 6;
            // 
            // MaNV_BLNV
            // 
            this.MaNV_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaNV_BLNV.HeaderText = "Mã nhân viên";
            this.MaNV_BLNV.MinimumWidth = 8;
            this.MaNV_BLNV.Name = "MaNV_BLNV";
            this.MaNV_BLNV.ReadOnly = true;
            this.MaNV_BLNV.Width = 128;
            // 
            // HoTenNV_BLNV
            // 
            this.HoTenNV_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HoTenNV_BLNV.HeaderText = "Họ tên nhân viên";
            this.HoTenNV_BLNV.MinimumWidth = 8;
            this.HoTenNV_BLNV.Name = "HoTenNV_BLNV";
            this.HoTenNV_BLNV.ReadOnly = true;
            this.HoTenNV_BLNV.Width = 126;
            // 
            // PhongBan_BLNV
            // 
            this.PhongBan_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PhongBan_BLNV.HeaderText = "Phòng ban";
            this.PhongBan_BLNV.MinimumWidth = 8;
            this.PhongBan_BLNV.Name = "PhongBan_BLNV";
            this.PhongBan_BLNV.ReadOnly = true;
            this.PhongBan_BLNV.Width = 113;
            // 
            // ChuVu_BLNV
            // 
            this.ChuVu_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChuVu_BLNV.HeaderText = "Chức vụ";
            this.ChuVu_BLNV.MinimumWidth = 8;
            this.ChuVu_BLNV.Name = "ChuVu_BLNV";
            this.ChuVu_BLNV.ReadOnly = true;
            this.ChuVu_BLNV.Width = 95;
            // 
            // LuongCoBan_BLNV
            // 
            this.LuongCoBan_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LuongCoBan_BLNV.HeaderText = "Lương cơ bản";
            this.LuongCoBan_BLNV.MinimumWidth = 8;
            this.LuongCoBan_BLNV.Name = "LuongCoBan_BLNV";
            this.LuongCoBan_BLNV.ReadOnly = true;
            this.LuongCoBan_BLNV.Width = 107;
            // 
            // PhuCap_BLNV
            // 
            this.PhuCap_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PhuCap_BLNV.HeaderText = "Phụ cấp";
            this.PhuCap_BLNV.MinimumWidth = 8;
            this.PhuCap_BLNV.Name = "PhuCap_BLNV";
            this.PhuCap_BLNV.ReadOnly = true;
            this.PhuCap_BLNV.Width = 96;
            // 
            // Thuong_BLNV
            // 
            this.Thuong_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Thuong_BLNV.HeaderText = "Thưởng";
            this.Thuong_BLNV.MinimumWidth = 8;
            this.Thuong_BLNV.Name = "Thuong_BLNV";
            this.Thuong_BLNV.ReadOnly = true;
            this.Thuong_BLNV.Width = 99;
            // 
            // KhauTru_BLNV
            // 
            this.KhauTru_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KhauTru_BLNV.HeaderText = "Khấu trừ";
            this.KhauTru_BLNV.MinimumWidth = 8;
            this.KhauTru_BLNV.Name = "KhauTru_BLNV";
            this.KhauTru_BLNV.ReadOnly = true;
            this.KhauTru_BLNV.Width = 98;
            // 
            // ThucLanh_BLNV
            // 
            this.ThucLanh_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThucLanh_BLNV.HeaderText = "Thực lãnh";
            this.ThucLanh_BLNV.MinimumWidth = 8;
            this.ThucLanh_BLNV.Name = "ThucLanh_BLNV";
            this.ThucLanh_BLNV.ReadOnly = true;
            this.ThucLanh_BLNV.Width = 106;
            // 
            // ThangLam_BLNV
            // 
            this.ThangLam_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThangLam_BLNV.HeaderText = "Tháng làm";
            this.ThangLam_BLNV.MinimumWidth = 8;
            this.ThangLam_BLNV.Name = "ThangLam_BLNV";
            this.ThangLam_BLNV.ReadOnly = true;
            this.ThangLam_BLNV.Width = 110;
            // 
            // GhiChu_BLNV
            // 
            this.GhiChu_BLNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GhiChu_BLNV.HeaderText = "Ghi chú";
            this.GhiChu_BLNV.MinimumWidth = 8;
            this.GhiChu_BLNV.Name = "GhiChu_BLNV";
            this.GhiChu_BLNV.ReadOnly = true;
            this.GhiChu_BLNV.Width = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 79);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tổng lương: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lableTongLuongBLNV
            // 
            this.lableTongLuongBLNV.AutoSize = true;
            this.lableTongLuongBLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lableTongLuongBLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableTongLuongBLNV.Location = new System.Drawing.Point(145, 472);
            this.lableTongLuongBLNV.Name = "lableTongLuongBLNV";
            this.lableTongLuongBLNV.Size = new System.Drawing.Size(403, 79);
            this.lableTongLuongBLNV.TabIndex = 8;
            this.lableTongLuongBLNV.Text = "    ";
            this.lableTongLuongBLNV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.Controls.Add(this.buttonSuaBLNV, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonXoaBLNV, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonXuatExcelBLNV, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(145, 554);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(694, 81);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // buttonSuaBLNV
            // 
            this.buttonSuaBLNV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSuaBLNV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonSuaBLNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonSuaBLNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonSuaBLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSuaBLNV.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuaBLNV.ForeColor = System.Drawing.Color.White;
            this.buttonSuaBLNV.Location = new System.Drawing.Point(3, 3);
            this.buttonSuaBLNV.Name = "buttonSuaBLNV";
            this.buttonSuaBLNV.Size = new System.Drawing.Size(208, 75);
            this.buttonSuaBLNV.TabIndex = 0;
            this.buttonSuaBLNV.Text = "Sửa";
            // 
            // buttonXoaBLNV
            // 
            this.buttonXoaBLNV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonXoaBLNV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonXoaBLNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonXoaBLNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonXoaBLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonXoaBLNV.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoaBLNV.ForeColor = System.Drawing.Color.White;
            this.buttonXoaBLNV.Location = new System.Drawing.Point(258, 3);
            this.buttonXoaBLNV.Name = "buttonXoaBLNV";
            this.buttonXoaBLNV.Size = new System.Drawing.Size(213, 75);
            this.buttonXoaBLNV.TabIndex = 1;
            this.buttonXoaBLNV.Text = "Xóa";
            // 
            // buttonXuatExcelBLNV
            // 
            this.buttonXuatExcelBLNV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonXuatExcelBLNV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonXuatExcelBLNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonXuatExcelBLNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonXuatExcelBLNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonXuatExcelBLNV.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXuatExcelBLNV.ForeColor = System.Drawing.Color.White;
            this.buttonXuatExcelBLNV.Location = new System.Drawing.Point(508, 3);
            this.buttonXuatExcelBLNV.Name = "buttonXuatExcelBLNV";
            this.buttonXuatExcelBLNV.Size = new System.Drawing.Size(183, 75);
            this.buttonXuatExcelBLNV.TabIndex = 2;
            this.buttonXuatExcelBLNV.Text = "Xuất Excel";
            // 
            // UC_BangLuongNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_BangLuongNV";
            this.Size = new System.Drawing.Size(1784, 728);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button buttonTimBLNV;
        private Guna.UI2.WinForms.Guna2TextBox textBoxTenNV_BLNV;
        private Guna.UI2.WinForms.Guna2ComboBox comBoxPhongBanBLNV;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateThangLuongBLNV;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNV_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongBan_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuVu_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuongCoBan_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhuCap_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thuong_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhauTru_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThucLanh_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThangLam_BLNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu_BLNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lableTongLuongBLNV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button buttonSuaBLNV;
        private Guna.UI2.WinForms.Guna2Button buttonXoaBLNV;
        private Guna.UI2.WinForms.Guna2Button buttonXuatExcelBLNV;
    }
}
