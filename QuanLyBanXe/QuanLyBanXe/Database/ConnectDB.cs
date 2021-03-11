using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanXe.Database
{
    class ConnectDB
    {
        public static SqlConnection getDBConnection()
        {
            //String connString = @"Data Source=DESKTOP-UORBSEQ\SQLEXPRESS;Initial Catalog=QuanLyBanXe;Integrated Security=True";
            String connString = @"Data Source=DESKTOP-DLGAGN4\SQLEXPRESS;Initial Catalog=QuanLyBanXe;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
