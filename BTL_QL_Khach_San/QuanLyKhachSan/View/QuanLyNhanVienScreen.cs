using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Entity;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.View
{
    public partial class QuanLyNhanVienScreen : Form
    {
        NhanVien nhanVien;
      
        public QuanLyNhanVienScreen()
        {

            InitializeComponent();
            cmbChucVu.Text = "Quản lý";
            cmbGioiTinh.Text = "Nam";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Model.ExcuteAdd.ThemNhanVien(txtManv, txtTennv, txtDiaChi,txtSDT,
                cmbChucVu, dtpNgaySinh,cmbGioiTinh, txtTaiKhoan, txtMatKhau);
            QuanLyNhanVienScreen_Load(sender, e);
            
            
        }

        private void QuanLyNhanVienScreen_Load(object sender, EventArgs e)
        {
            Model.LoadUtil.taiDuLieuVaoBang(dtgDanhSachNhanVien,"NhanVien");
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            Model.ExcuteDelete.XoaNhanVien(txtManv, txtTennv, txtDiaChi, txtSDT,
                cmbChucVu, dtpNgaySinh, cmbGioiTinh, txtTaiKhoan, txtMatKhau);
            QuanLyNhanVienScreen_Load(sender, e);
            
            
        }

        private void dtgDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            CellClickTableContent.cellClickTableNhanVien(txtManv, txtTennv, txtDiaChi, txtSDT, cmbChucVu, 
                dtpNgaySinh, cmbGioiTinh, txtTaiKhoan, txtMatKhau,ref nhanVien, dtgDanhSachNhanVien, e.RowIndex);
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Model.ExcuteUpdate.CapNhatNhanVien(txtManv, txtTennv, txtDiaChi, txtSDT, cmbChucVu, dtpNgaySinh, 
                cmbGioiTinh, txtTaiKhoan, txtMatKhau, nhanVien);
            QuanLyNhanVienScreen_Load(sender, e);
               
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadUtil.timKiemNhanVien(txtTKTenNV.Text, dtgDanhSachNhanVien);
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            QuanLyNhanVienScreen_Load(sender, e);
            txtTKTenNV.Text = "";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dtgDanhSachNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
