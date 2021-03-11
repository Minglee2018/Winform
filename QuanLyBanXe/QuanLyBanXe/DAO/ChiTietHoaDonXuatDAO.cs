using QuanLyBanXe.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanXe.DAO
{
    class ChiTietHoaDonXuatDAO
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public DataTable getDSXe()
        {
            conn.Open();
            String sql = "SELECT * FROM XE";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public DataTable getDSXeTheoMaHD(string maHDX)
        {
            conn.Open();
            String sql = "SELECT Xe.maXe,Xe.tenXe,soLuong,Xe.giaBan,thueVAT,thanhTien FROM ChiTietHDXuat,Xe"+
                            " WHERE Xe.maXe = ChiTietHDXuat.maXe AND maHDX = '"+maHDX+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public DataTable getDSXeTheoTen(string key)
        {
            conn.Open();
            String sql = "SELECT * FROM XE WHERE tenXE LIKE '%"+key+"%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public void insertChiTietHDX(string maHDX, string maXe, int soLuong, double thueVAT, double thanhTien)
        {
            conn.Open();
            String sql = "INSERT INTO CHITIETHDXUAT VALUES(@maHDX, @maXe, @soLuong, @thueVAT, @thanhTien)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHDX);
            cmd.Parameters.AddWithValue("@maXe", maXe);
            cmd.Parameters.AddWithValue("@soLuong", soLuong);
            cmd.Parameters.AddWithValue("@thueVAT", thueVAT);
            cmd.Parameters.AddWithValue("@thanhTien", thanhTien);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateChiTietHDX(string maHDX, string maXe, int soLuong, double thueVAT, double thanhTien)
        {
            conn.Open();
            String sql = "UPDATE CHITIETHDXUAT SET soLuong = @soLuong, thueVAT = @thueVAT, thanhTien = @thanhTien" +
                " WHERE maHDX = @maHDX AND maXE = @maXe";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHDX);
            cmd.Parameters.AddWithValue("@maXe", maXe);
            cmd.Parameters.AddWithValue("@soLuong", soLuong);
            cmd.Parameters.AddWithValue("@thueVAT", thueVAT);
            cmd.Parameters.AddWithValue("@thanhTien", thanhTien);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Boolean checkExistXeXuat(string maHDX, string maXe)
        {
            conn.Open();
            Boolean flag = false;
            String sql = "SELECT * FROM CHITIETHDXUAT WHERE maHDX = @maHDX AND maXE = @maXe";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHDX);
            cmd.Parameters.AddWithValue("@maXe", maXe);
            SqlDataReader dread = cmd.ExecuteReader();
            if (dread.HasRows)
                flag = true;
            conn.Close();
            return flag;
        }

        public void deleteChiTietHDX(string maHDX, string maXe)
        {
            conn.Open();
            String sql = "DELETE FROM CHITIETHDXUAT WHERE maHDX = @maHDX AND maXE = @maXe";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHDX);
            cmd.Parameters.AddWithValue("@maXe", maXe);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Double getTongThanhTien(string maHDX)
        {
            conn.Open();
            Double soLuong = 0;
            String sql = "SELECT SUM(thanhTien) as 'tt' FROM CHITIETHDXUAT WHERE maHDX = @maHDX";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maHDX", maHDX);
            SqlDataReader dread = cmd.ExecuteReader();
            if (dread.HasRows)
            {
                if (dread.Read())
                    soLuong = dread.GetDouble(0);
            }
            conn.Close();
            return soLuong;
        }
    }
}
