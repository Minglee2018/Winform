using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyKhachSan.Connection;
using System.Windows.Forms;

namespace QuanLyKhachSan.Model
{
    class LoadUtil
    {
        public static void taiDuLieuVaoBang(DataGridView dtgThongTin, String tenBang)
        {
            String query = "Select * from " +tenBang;
            dtgThongTin.DataSource = Connection.DBConnection.getTable(query);
        }

        public static void timKiemDuLieuPhong(DataGridView dtgThongTin, String tenBang, String loaiPhong)
        {
            //String query = "select * from " + tenBang + " where loaiphong = " + loaiPhong;
            string query1 = "";
            if (loaiPhong == "Tất cả")
            {
                query1 = "select * from " + tenBang;
            }
            else
            {
                query1 = "select * from " + tenBang + " where loaiPhong = N'" + loaiPhong + "'";
            }
            
          
            dtgThongTin.DataSource = Connection.DBConnection.getTable(query1);
        }


        public static void cleanQuanLyNhanVienScreen(TextBox ma, TextBox ten, TextBox sdt,TextBox diaChi,
            TextBox tenDN, TextBox mk)
        {
            ma.Text = "";
            ten.Text = "";
            sdt.Text = "";
            diaChi.Text = "";
            tenDN.Text = "";
            mk.Text = "";
           
        }

        public static void timKiemNhanVien(String dieuKien, DataGridView dtg)
        {
            if (dieuKien.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập Số CMT/Tên nhân viên cần tìm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String query = "select * from NhanVien where tennv like N'%" + dieuKien + "%' or manv like '%" + dieuKien + "%'";
                dtg.DataSource = DBConnection.getTable(query);
            }
            
        }
    }
}
