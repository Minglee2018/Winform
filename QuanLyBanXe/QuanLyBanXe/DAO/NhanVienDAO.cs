using QuanLyBanXe.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanXe.DAO
{
    class NhanVienDAO
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public Boolean checkExistAccNV(String taiKhoan, String matKhau)
        {
            conn.Open();
            Boolean flag = false;
            String sql = "SELECT * FROM NHANVIEN WHERE maNV = @maNV AND matKhau = @matKhau";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maNV", taiKhoan);
            cmd.Parameters.AddWithValue("@matKhau", matKhau);
            SqlDataReader dread = cmd.ExecuteReader();
            if (dread.HasRows)
                flag = true;
            conn.Close();
            return flag;
        }
    }
}
