using QuanLyBanXe.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanXe.DAO
{
    class AdminDAO
    {
        SqlConnection conn = ConnectDB.getDBConnection();

        public Boolean checkExistAccAdmin(String taiKhoan, String matKhau)
        {
            conn.Open();
            Boolean flag = false;
            String sql = "SELECT * FROM ADMIN WHERE taiKhoan = @taiKhoan AND matKhau = @matKhau";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@taiKhoan", taiKhoan);
            cmd.Parameters.AddWithValue("@matKhau", matKhau);
            SqlDataReader dread = cmd.ExecuteReader();
            if (dread.HasRows)
                flag = true;
            conn.Close();
            return flag;
        }
    }
}
