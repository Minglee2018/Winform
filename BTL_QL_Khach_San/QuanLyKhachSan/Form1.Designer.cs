namespace QuanLyKhachSan
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPhong,
            this.menuKhachHang,
            this.menuDichVu,
            this.menuHoaDon,
            this.menuDangXua});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1205, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
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
            this.menuKhachHang.Size = new System.Drawing.Size(120, 23);
            this.menuKhachHang.Text = "Khách Hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // menuDichVu
            // 
            this.menuDichVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDichVu.Image = ((System.Drawing.Image)(resources.GetObject("menuDichVu.Image")));
            this.menuDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuDichVu.Name = "menuDichVu";
            this.menuDichVu.Size = new System.Drawing.Size(91, 23);
            this.menuDichVu.Text = "Dịch Vụ";
            this.menuDichVu.Click += new System.EventHandler(this.menuDichVu_Click);
            // 
            // menuHoaDon
            // 
            this.menuHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("menuHoaDon.Image")));
            this.menuHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuHoaDon.Name = "menuHoaDon";
            this.menuHoaDon.Size = new System.Drawing.Size(98, 23);
            this.menuHoaDon.Text = "Hóa Đơn";
            this.menuHoaDon.Click += new System.EventHandler(this.menuHoaDon_Click);
            // 
            // menuDangXua
            // 
            this.menuDangXua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDangXua.Image = ((System.Drawing.Image)(resources.GetObject("menuDangXua.Image")));
            this.menuDangXua.Name = "menuDangXua";
            this.menuDangXua.Size = new System.Drawing.Size(109, 23);
            this.menuDangXua.Text = "Đăng Xuất";
            this.menuDangXua.Click += new System.EventHandler(this.menuDangXua_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 518);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuDichVu;
        private System.Windows.Forms.ToolStripMenuItem menuPhong;
        private System.Windows.Forms.ToolStripMenuItem menuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem menuDangXua;
    }
}

