namespace QuanLyKhachSan.View
{
    partial class DatPhongScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatPhongScreen));
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dtgThongTinPhong = new System.Windows.Forms.DataGridView();
            this.soPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrang = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtCMT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayDat = new System.Windows.Forms.DateTimePicker();
            this.cmbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgThongTinPhong)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDatPhong
            // 
            resources.ApplyResources(this.btnDatPhong, "btnDatPhong");
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.UseVisualStyleBackColor = true;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnHuy);
            this.groupBox5.Controls.Add(this.btnDatPhong);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btnHuy
            // 
            resources.ApplyResources(this.btnHuy, "btnHuy");
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dtgThongTinPhong
            // 
            this.dtgThongTinPhong.AllowUserToAddRows = false;
            this.dtgThongTinPhong.AllowUserToDeleteRows = false;
            this.dtgThongTinPhong.AllowUserToResizeColumns = false;
            this.dtgThongTinPhong.AllowUserToResizeRows = false;
            this.dtgThongTinPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgThongTinPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.soPhong,
            this.loaiPhong,
            this.tinhTrang,
            this.gia});
            resources.ApplyResources(this.dtgThongTinPhong, "dtgThongTinPhong");
            this.dtgThongTinPhong.Name = "dtgThongTinPhong";
            this.dtgThongTinPhong.ReadOnly = true;
            this.dtgThongTinPhong.RowHeadersVisible = false;
            this.dtgThongTinPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgThongTinPhong_CellClick);
            // 
            // soPhong
            // 
            this.soPhong.DataPropertyName = "sophong";
            resources.ApplyResources(this.soPhong, "soPhong");
            this.soPhong.Name = "soPhong";
            this.soPhong.ReadOnly = true;
            this.soPhong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // loaiPhong
            // 
            this.loaiPhong.DataPropertyName = "loaiPhong";
            resources.ApplyResources(this.loaiPhong, "loaiPhong");
            this.loaiPhong.Name = "loaiPhong";
            this.loaiPhong.ReadOnly = true;
            this.loaiPhong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tinhTrang
            // 
            this.tinhTrang.DataPropertyName = "tinhTrang";
            resources.ApplyResources(this.tinhTrang, "tinhTrang");
            this.tinhTrang.Name = "tinhTrang";
            this.tinhTrang.ReadOnly = true;
            this.tinhTrang.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tinhTrang.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gia
            // 
            this.gia.DataPropertyName = "gia";
            resources.ApplyResources(this.gia, "gia");
            this.gia.Name = "gia";
            this.gia.ReadOnly = true;
            this.gia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgThongTinPhong);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtSoPhong, "txtSoPhong");
            this.txtSoPhong.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhong.Name = "txtSoPhong";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbGioiTinh);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.dtpNgaySinh);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtSDT);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtDiaChi);
            this.groupBox4.Controls.Add(this.txtCMT);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtTenKH);
            this.groupBox4.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // cmbGioiTinh
            // 
            this.cmbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGioiTinh.FormattingEnabled = true;
            this.cmbGioiTinh.Items.AddRange(new object[] {
            resources.GetString("cmbGioiTinh.Items"),
            resources.GetString("cmbGioiTinh.Items1")});
            resources.ApplyResources(this.cmbGioiTinh, "cmbGioiTinh");
            this.cmbGioiTinh.Name = "cmbGioiTinh";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpNgaySinh, "dtpNgaySinh");
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtSDT
            // 
            resources.ApplyResources(this.txtSDT, "txtSDT");
            this.txtSDT.Name = "txtSDT";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtDiaChi
            // 
            resources.ApplyResources(this.txtDiaChi, "txtDiaChi");
            this.txtDiaChi.Name = "txtDiaChi";
            // 
            // txtCMT
            // 
            resources.ApplyResources(this.txtCMT, "txtCMT");
            this.txtCMT.Name = "txtCMT";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtTenKH
            // 
            resources.ApplyResources(this.txtTenKH, "txtTenKH");
            this.txtTenKH.Name = "txtTenKH";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpNgayDat);
            this.groupBox1.Controls.Add(this.cmbLoaiPhong);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dtpNgayDat
            // 
            resources.ApplyResources(this.dtpNgayDat, "dtpNgayDat");
            this.dtpNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDat.Name = "dtpNgayDat";
            // 
            // cmbLoaiPhong
            // 
            this.cmbLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiPhong.FormattingEnabled = true;
            this.cmbLoaiPhong.Items.AddRange(new object[] {
            resources.GetString("cmbLoaiPhong.Items"),
            resources.GetString("cmbLoaiPhong.Items1"),
            resources.GetString("cmbLoaiPhong.Items2"),
            resources.GetString("cmbLoaiPhong.Items3"),
            resources.GetString("cmbLoaiPhong.Items4")});
            resources.ApplyResources(this.cmbLoaiPhong, "cmbLoaiPhong");
            this.cmbLoaiPhong.Name = "cmbLoaiPhong";
            this.cmbLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiPhong_SelectedIndexChanged);
            this.cmbLoaiPhong.SelectionChangeCommitted += new System.EventHandler(this.cmbLoaiPhong_SelectionChangeCommitted);
            this.cmbLoaiPhong.SelectedValueChanged += new System.EventHandler(this.cmbLoaiPhong_SelectedValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtGia
            // 
            resources.ApplyResources(this.txtGia, "txtGia");
            this.txtGia.Name = "txtGia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtGia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSoPhong);
            this.groupBox2.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // DatPhongScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DatPhongScreen";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.DatPhongScreen_Load);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgThongTinPhong)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dtgThongTinPhong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtCMT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayDat;
        private System.Windows.Forms.ComboBox cmbLoaiPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn soPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiPhong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn gia;
    }
}