using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Connection;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Model
{
    class ExcuteUpdate
    {
        public static void CapNhatNhanVien(TextBox ma, TextBox ten, TextBox diaChi,
            TextBox sdt, ComboBox chucVu, DateTimePicker ngaySinh, ComboBox gt,
            TextBox tk, TextBox mk, NhanVien nv)
        {
            if (ma.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ten.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (diaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập địa chỉ nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sdt.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập số điện thoại của nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tk.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập tài khoản đăng nhập của nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (mk.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập mật khẩu đăng nhập nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!KiemTra.kiemTraTonTai("select manv from NhanVien", ma.Text.Trim()))
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean gioiTinh;
                    if (gt.Text.Equals("Nam"))
                    {
                        gioiTinh = true;
                    }
                    else
                    {
                        gioiTinh = false;
                    }
                    String query = "update NhanVien set tennv = N'"+ten.Text.Trim()+"'" +
                        ", diachi = N'"+diaChi.Text.Trim() + "'" +
                        ", sdt = '"+sdt.Text.Trim() + "'" +
                        ", chucvu = N'"+chucVu.Text.Trim() + "'" +
                        ", ngaysinh = '"+ngaySinh.Value.ToString()+"'" +
                        ", gioitinh = '"+gioiTinh+"'" +
                        ", taikhoan = '"+tk.Text.Trim() + "'" +
                        ", matkhau = '"+mk.Text.Trim() + "'" +
                        " where manv = '"+ma.Text.Trim() + "'";
                    
                    if (nv.TaiKhoan.Trim().Equals(tk.Text.Trim()))
                    {
                        DBConnection.ExcuteQuery(query);
                        LoadUtil.cleanQuanLyNhanVienScreen(ma, ten, sdt, diaChi, tk, mk);
                    }
                    else
                    {
                        if (!KiemTra.kiemTraTonTai("select taikhoan from NhanVien", tk.Text.Trim()))
                        {
                            DBConnection.ExcuteQuery(query);
                            LoadUtil.cleanQuanLyNhanVienScreen(ma, ten, sdt, diaChi, tk, mk);
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   
                }
            }

        }
    }
}
