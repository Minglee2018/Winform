using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Model;
using System.Windows.Forms;
using System.Threading;
using QuanLyKhachSan.Connection;
using System.Data.SqlClient;
using QuanLyKhachSan.View;

namespace QuanLyKhachSan.Model
{
    class KiemTra
    {
        public static void dangNhap(String tk, String mk, String cv, Form form)
        {
            
            if (tk.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (mk.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập mật khẩu!","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Util.kiemTraDangNhap(tk, mk, cv, "NhanVien"))
                {
                    if (cv.Trim().Equals("Nhân viên"))
                    {
                        Form1 f = new Form1(form);
                        f.Show();
                        form.Hide();
                    }else if (cv.Trim().Equals("Quản lý"))
                    {
                        ManHinhQuanLy manHinhQuanLy = new ManHinhQuanLy(form);
                        manHinhQuanLy.Show();
                        form.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản, mật khẩu hoặc chức vụ!");
                }
            }
        
        }

       public static Boolean kiemTraTonTai(String query, String key)
        {

            SqlDataReader reader = DBConnection.getDataReader(query);
            while (reader.Read())
            {
                /*if (reader.GetString(0).Trim() == key)
                {
                    return true;
                }*/
                if (reader.GetValue(0).ToString().Trim() == key)
                {
                    return true;
                }
                
            }
            return false;
        }
      

     
    }
  
}
