using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Model
{
    class CellClickTableContent
    {
        public static void cellClickTableNhanVien(TextBox txtManv, TextBox txtTennv, TextBox txtDiaChi, TextBox txtSDT,
            ComboBox cmbChucVu, DateTimePicker dtpNgaySinh, ComboBox cmbGioiTinh, TextBox txtTaiKhoan, 
            TextBox txtMatKhau,ref NhanVien nhanVien, DataGridView dtgDanhSachNhanVien, int index)
        {
            txtManv.Text = dtgDanhSachNhanVien.Rows[index].Cells[0].Value.ToString().Trim();
            txtTennv.Text = dtgDanhSachNhanVien.Rows[index].Cells[1].Value.ToString().Trim();
            txtDiaChi.Text = dtgDanhSachNhanVien.Rows[index].Cells[2].Value.ToString().Trim();
            txtSDT.Text = dtgDanhSachNhanVien.Rows[index].Cells[3].Value.ToString().Trim();
            cmbChucVu.Text = dtgDanhSachNhanVien.Rows[index].Cells[4].Value.ToString().Trim();
            dtpNgaySinh.Text = dtgDanhSachNhanVien.Rows[index].Cells[5].Value.ToString().Trim();
            if (dtgDanhSachNhanVien.Rows[index].Cells[6].Value.ToString().Equals("True"))
            {
                cmbGioiTinh.Text = "Nam";
            }
            else
            {
                cmbGioiTinh.Text = "Nữ";
            }
            txtTaiKhoan.Text = dtgDanhSachNhanVien.Rows[index].Cells[7].Value.ToString().Trim();
            txtMatKhau.Text = dtgDanhSachNhanVien.Rows[index].Cells[8].Value.ToString().Trim();
            NhanVien nv = new NhanVien(txtManv.Text.Trim(), txtTennv.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim(),
                cmbChucVu.Text.Trim(), dtpNgaySinh.Text.Trim(), cmbGioiTinh.Text.Trim(), txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()
                );
            nhanVien = nv;
        }

        public static void cellClickTableDatPhong(TextBox txtSoPhong, TextBox txtGia, ComboBox cmbLoaiPhong,
            ref Entity.Phong phong , DataGridView dtgThongTinPhong, int index)
        {
            txtSoPhong.Text = dtgThongTinPhong.Rows[index].Cells[0].Value.ToString().Trim();
            txtGia.Text = dtgThongTinPhong.Rows[index].Cells[3].Value.ToString().Trim();
            cmbLoaiPhong.Text = dtgThongTinPhong.Rows[index].Cells[1].Value.ToString().Trim();
            Entity.Phong p = new Entity.Phong(int.Parse(txtSoPhong.Text), cmbLoaiPhong.Text,
                                Boolean.Parse(dtgThongTinPhong.Rows[index].Cells[2].Value.ToString()),
                                Double.Parse(txtGia.Text));
            phong = p;
        }
    }
}
