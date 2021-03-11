using QuanLyBanXe.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanXe.DAO
{
    class HoaDonXuatDAO
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public DataTable getDSKhachHang()
        {
            conn.Open();
            String sql = "SELECT * FROM KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public DataTable getDSKhachHangTheoTen(String tenKH)
        {
            conn.Open();
            String sql = "SELECT * FROM KHACHHANG WHERE tenKH LIKE '%" + tenKH + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        public DataTable getDSHoaDonTheoNV(String userLogin)
        {
            conn.Open();
            String sql = "SELECT * FROM HOADONXUAT WHERE maNV = '"+userLogin+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql,conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public void createHoaDon(string maHD, string maNV, string maKH, DateTime ngayXuat)
        {
            conn.Open();
            String sql = "INSERT INTO HOADONXUAT VALUES(@maHDX, @maNV, @maKH, @ngayXuat)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHD);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.Parameters.AddWithValue("@maKH", maKH);
            cmd.Parameters.AddWithValue("@ngayXuat", ngayXuat);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Boolean checkExistHoaDon(String maHD)
        {
            conn.Open();
            Boolean flag = false;
            String sql = "SELECT * FROM HOADONXUAT WHERE maHDX = @maHDX";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHD);
            SqlDataReader dread = cmd.ExecuteReader();
            if (dread.HasRows)
                flag = true;
            conn.Close();
            return flag;
        }

        public void updateHoaDon(string maHD, string maNV, string maKH, DateTime ngayXuat)
        {
            conn.Open();
            String sql = "UPDATE HOADONXUAT SET maNV = @maNV, maKH = @maKH, ngayXuat = @ngayXuat WHERE maHDX = @maHDX";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHD);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.Parameters.AddWithValue("@maKH", maKH);
            cmd.Parameters.AddWithValue("@ngayXuat", ngayXuat);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteHoaDon(string maHD)
        {
            conn.Open();
            String sql = "DELETE FROM HOADONXUAT WHERE maHDX = @maHDX";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHD);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteChiTietHoaDon(String maHD)
        {
            conn.Open();
            String sql = "DELETE FROM CHITIETHDXUAT WHERE maHDX = @maHDX";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHD);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
