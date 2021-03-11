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
    public partial class MenuNhanVien : Form
    {
        private String userLogin;
        public MenuNhanVien()
        {
            InitializeComponent();
        }
        public MenuNhanVien(String userLogin) : this()
        {
            this.userLogin = userLogin;
        }
        private void HoaDonXuat_Click(object sender, EventArgs e)
        {
            HoaDonXuat frmHDX = new HoaDonXuat(this.userLogin);
            this.Hide();
            frmHDX.Show();
        }

        private void PhieuBaoHanh_Click(object sender, EventArgs e)
        {
            LapPhieuBaoHanh frmPhieuBH = new LapPhieuBaoHanh(this.userLogin);
            this.Hide();
            frmPhieuBH.Show();
        }

        private void cậpNhậtThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapNhatThongTinKhachHang frmCapNhatKH = new CapNhatThongTinKhachHang(this.userLogin);
            this.Hide();
            frmCapNhatKH.Show();
        }

        private void tìmKiếmThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemThongTinKhachHang frmTimKiemKH = new TimKiemThongTinKhachHang(this.userLogin);
            this.Hide();
            frmTimKiemKH.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonNhap frmHDN = new HoaDonNhap(this.userLogin);
            this.Hide();
            frmHDN.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            TimKiemThongTinXe frmTimKiemXe = new TimKiemThongTinXe(this.userLogin);
            this.Hide();
            frmTimKiemXe.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DangNhap frmDN = new DangNhap();
            this.Dispose();
            frmDN.Show();
        }
    }
}
