using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyKhachSan.Connection;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.Model
{
    class ExcuteDelete
    {
        public static void XoaNhanVien(TextBox ma, TextBox ten, TextBox diaChi,
            TextBox sdt, ComboBox chucVu, DateTimePicker ngaySinh, ComboBox gt, TextBox tk, TextBox mk)
        {
            if (ma.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String query = "Select manv from NhanVien";
                if (!KiemTra.kiemTraTonTai(query, ma.Text.Trim()))
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc xóa nhân viên này!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        String deleteQuery = "delete NhanVien where manv = '" + ma.Text.Trim() + "'";
                        if (DBConnection.ExcuteQuery(deleteQuery))
                        {
                            LoadUtil.cleanQuanLyNhanVienScreen(ma, ten, sdt, diaChi, tk, mk);
                        }
                    }
                   
                }
            }
           
        }
    }
}
