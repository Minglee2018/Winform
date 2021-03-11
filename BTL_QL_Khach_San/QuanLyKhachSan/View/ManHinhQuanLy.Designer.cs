namespace QuanLyKhachSan.View
{
    partial class ManHinhQuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManHinhQuanLy));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNhanVien,
            this.menuDichVu,
            this.menuPhong,
            this.menuKhachHang,
            this.menuDangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1191, 27);
            this.menuStrip1.TabIndex = 0;
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("menuNhanVien.Image")));
            this.menuNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(105, 23);
            this.menuNhanVien.Text = "Nhân viên";
            this.menuNhanVien.Click += new System.EventHandler(this.menuNhanVien_Click);
            // 
            // menuDichVu
            // 
            this.menuDichVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDichVu.Image = ((System.Drawing.Image)(resources.GetObject("menuDichVu.Image")));
            this.menuDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuDichVu.Name = "menuDichVu";
            this.menuDichVu.Size = new System.Drawing.Size(92, 23);
            this.menuDichVu.Text = "Dịch vụ ";
            this.menuDichVu.Click += new System.EventHandler(this.menuDichVu_Click);
            // 
            // menuPhong
            // 
            this.menuPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPhong.Image = ((System.Drawing.Image)(resources.GetObject("menuPhong.Image")));
            this.menuPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuPhong.Name = "menuPhong";
            this.menuPhong.Size = new System.Drawing.Size(78, 23);
            this.menuPhong.Text = "Phòng";
            this.menuPhong.Click += new System.EventHandler(this.menuPhong_Click);
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("menuKhachHang.Image")));
            this.menuKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.Size = new System.Drawing.Size(116, 23);
            this.menuKhachHang.Text = "Khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("menuDangXuat.Image")));
            this.menuDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(106, 23);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // ManHinhQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 509);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManHinhQuanLy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManHinhQuanLy_FormClosed);
            this.Load += new System.EventHandler(this.ManHinhQuanLy_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuDichVu;
        private System.Windows.Forms.ToolStripMenuItem menuPhong;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
    }
}