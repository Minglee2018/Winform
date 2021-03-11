using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLyKhachSan.Connection
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            string strConnect = @"Data Source=DESKTOP-6PC73Q3\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
            return new SqlConnection(strConnect);
        }

        public static DataTable getTable(String query)
        {
            SqlConnection connection = DBConnection.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static Boolean ExcuteQuery(String query)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
    
    
            /*try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi truy vấn scdl!", "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
            return false;*/
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
            return true;

        }

        public static SqlDataReader getDataReader(String query)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

    }
}
