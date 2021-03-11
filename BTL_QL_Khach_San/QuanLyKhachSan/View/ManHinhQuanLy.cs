using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.View
{
    public partial class ManHinhQuanLy : Form
    {
        static QuanLyNhanVienScreen quanLyNhanVienScreen;
        static DichVuScreen dichVuScreen;
        static View.Phong phongScreen;
        static KhachHangScreen khachHangScreen;
        private Form form;
        
        public ManHinhQuanLy()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        public ManHinhQuanLy(Form form)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.form = form;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void ManHinhQuanLy_Load(object sender, EventArgs e)
        {
            /*quanLyNhanVienScreen = new QuanLyNhanVienScreen();
            quanLyNhanVienScreen.MdiParent = this;
            quanLyNhanVienScreen.StartPosition = FormStartPosition.Manual;
            quanLyNhanVienScreen.Location = new Point(0,0);
            quanLyNhanVienScreen.Show*/
            Model.Util.createMDIChild("QuanLyNhanVienScreen", this, quanLyNhanVienScreen);
        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            Model.Util.createMDIChild("QuanLyNhanVienScreen",this, quanLyNhanVienScreen);
        }

        private void menuDichVu_Click(object sender, EventArgs e)
        {
            Model.Util.createMDIChild("DichVuScreen", this, dichVuScreen);
        }

        private void menuPhong_Click(object sender, EventArgs e)
        {
            Model.Util.createMDIChild("Phong", this, phongScreen);
        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            Model.Util.createMDIChild("KhachHangScreen", this, khachHangScreen);
        }

        private void ManHinhQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.form.Close();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            this.form.Show();
            this.Hide();
        }
    }
}
