using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Model
{
    class ClickCancel
    {
        public static void CancelDatPhong(TextBox txtTenKH, TextBox soCMT, TextBox diaChi, TextBox sdt,
            ComboBox gioiTinh, DateTimePicker ngaySinh)
        {
            txtTenKH.Text = "";
            soCMT.Text = "";
            diaChi.Text = "";
            sdt.Text = "";
            gioiTinh.Text = "Nam";
            ngaySinh.Value = DateTime.Now;
        }
    }
}
