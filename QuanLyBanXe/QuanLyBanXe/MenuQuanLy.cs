using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanXe
{
    public partial class MenuQuanLy : Form
    {
        private String userlogin;
        public MenuQuanLy()
        {
            InitializeComponent();
        }
        public MenuQuanLy(string taikhoan)
        {
            InitializeComponent();
            this.userlogin = taikhoan;
        }

        private void MenuQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void cậpNhậToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapNhatThongTinNhanVien frmNhanVien = new CapNhatThongTinNhanVien();
            this.Hide();
            frmNhanVien.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CapNhatThongTinNhaCungCap frmNCC = new CapNhatThongTinNhaCungCap();
            this.Hide();
            frmNCC.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CapNhatTTX frmXe = new CapNhatTTX();
            this.Hide();
            frmXe.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void tìmKiếmThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemThongTinNhanVien frmTimKiemNV = new TimKiemThongTinNhanVien();
            this.Hide();
            frmTimKiemNV.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DangNhap frmDN = new DangNhap();
            this.Dispose();
            frmDN.Show();
        }
    }
}
