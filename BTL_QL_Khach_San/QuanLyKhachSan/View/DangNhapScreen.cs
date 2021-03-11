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
    public partial class DangNhapScreen : Form
    {
        public DangNhapScreen()
        {
            InitializeComponent();
            jcmbChucVu.Text = "Quản lý";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           Model.KiemTra.dangNhap(txtTenDangNhap.Text, txtMatKhau.Text, jcmbChucVu.Text, this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhapScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void DangNhapScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
