using System;
using QuanLyKhachSan.Model;
using QuanLyKhachSan.View;
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
    public partial class KhachHangScreen : Form
    {
        public KhachHangScreen()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhachHangScreen_Load(object sender, EventArgs e)
        {
            XuLy.hienthiKhachHang(dgvKhachHang);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XuLy.huyThongTinHienThi(txtCMT, txtTenKH, txtSDT, txtDiaChi, rdbNam);
            //this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy.themKhachHang(txtCMT, txtTenKH, txtSDT, txtDiaChi, rdbNam, dtpNgaySinh);
            KhachHangScreen_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XuLy.xoaKhachHang(txtCMT);
            KhachHangScreen_Load(sender, e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            XuLy.capnhatKhachHang(txtCMT, txtTenKH, txtSDT, txtDiaChi, rdbNam, dtpNgaySinh);
            KhachHangScreen_Load(sender, e);
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            XuLy.timKiemKhachHang(txtTimKienTenKH, txtTimKiemSoCMT, dgvKhachHang);
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int viTri = e.RowIndex;
            XuLy.CellClickBangKhachHang(txtCMT, txtTenKH, txtSDT, txtDiaChi, 
                rdbNam, rdbNu, dtpNgaySinh, dgvKhachHang, viTri);
        }

        private void btnHuyTK_Click(object sender, EventArgs e)
        {
            XuLy.hienthiKhachHang(dgvKhachHang);
            XuLy.huyThongTinTimKiem(txtTimKienTenKH, txtTimKiemSoCMT);
        }
    }
}
