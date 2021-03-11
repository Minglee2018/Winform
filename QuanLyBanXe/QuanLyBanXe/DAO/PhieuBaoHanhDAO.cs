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
    class PhieuBaoHanhDAO
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public DataTable getDSPhieuXuatTheoNV(string userLogin)
        {
            conn.Open();
            String sql = "SELECT HoaDonXuat.maHDX, ChiTietHDXuat.maXe, maNV, maKH,ngayXuat from HoaDonXuat, ChiTietHDXuat " +
                "WHERE HoaDonXuat.maHDX = ChiTietHDXuat.maHDX AND maNV = '"+ userLogin + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public DataTable getDSPhieuBHTheoNV(string userLogin)
        {
            conn.Open();
            String sql = "SELECT * FROM BAOHANH WHERE maNV = '"+userLogin+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public Boolean checkExistMaPhieuBH(string maPhieuBH)
        {
            conn.Open();
            Boolean flag = false;
            String sql = "SELECT * FROM BAOHANH WHERE maPhieuBH = @maPhieuBH";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maPhieuBH", maPhieuBH);
            SqlDataReader dread = cmd.ExecuteReader();
            if (dread.HasRows)
                flag = true;
            conn.Close();
            return flag;
        }
        public void createPhieuBH(string maPhieuBH, string maNV, string maKH, string maXe, string tGBH, DateTime ngayMua)
        {
            conn.Open();
            String sql = "INSERT INTO BAOHANH VALUES(@maPhieuBH,@maNV, @maKH,@maXe,@TGBH, @ngayMua)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maPhieuBH", maPhieuBH);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.Parameters.AddWithValue("@maKH", maKH);
            cmd.Parameters.AddWithValue("@maXe", maXe);
            cmd.Parameters.AddWithValue("@TGBH", tGBH);
            cmd.Parameters.AddWithValue("@ngayMua", ngayMua);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updatePhieuBH(string maPhieuBH, string maNV, string maKH, string maXe, string tGBH, DateTime ngayMua)
        {
            conn.Open();
            String sql = "UPDATE BAOHANH SET maNV = @maNV, maKH = @maKH, maXe = @maXe, TGBH = @TGBH, ngayMua = @ngayMua" +
                " WHERE maPhieuBH = @maPhieuBH";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maPhieuBH", maPhieuBH);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.Parameters.AddWithValue("@maKH", maKH);
            cmd.Parameters.AddWithValue("@maXe", maXe);
            cmd.Parameters.AddWithValue("@TGBH", tGBH);
            cmd.Parameters.AddWithValue("@ngayMua", ngayMua);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void deletePhieuBH(string maPhieuBH)
        {
            conn.Open();
            String sql = "DELETE FROM BAOHANH WHERE maPhieuBH = @maPhieuBH";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maPhieuBH", maPhieuBH);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
