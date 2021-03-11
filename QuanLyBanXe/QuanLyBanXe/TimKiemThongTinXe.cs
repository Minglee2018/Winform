using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanXe.Database;

namespace QuanLyBanXe
{

    public partial class TimKiemThongTinXe : Form
    {
        string userLogin;
        SqlConnection conn = ConnectDB.getDBConnection();
        public TimKiemThongTinXe()
        {
            InitializeComponent();
        }
        public TimKiemThongTinXe(string taiKhoan)
        {
            InitializeComponent();
            this.userLogin = taiKhoan;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuNhanVien menuNhanVien = new MenuNhanVien(this.userLogin);
            menuNhanVien.Show();
            this.Hide();
        }

        private void btnHienHet_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT * FROM Xe";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvXe.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaXe.Text.Trim() == "" && txtTenXe.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập vào MaXe, TenXe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql;
                if (txtMaXe.Text.Trim() != "" && txtTenXe.Text.Trim() == "")
                {
                    sql = "SELECT * FROM Xe WHERE maXe LIKE '" + txtMaXe.Text.Trim() + "%'";
                }
                else if (txtMaXe.Text.Trim() == "" && txtTenXe.Text.Trim() != "")
                {
                    sql = "SELECT * FROM Xe WHERE tenXe LIKE '%" + txtTenXe.Text.Trim() + "%'";
                }
                else
                {
                    sql = "SELECT * FROM Xe WHERE maXe LIKE '" + txtMaXe.Text.Trim() + "%'" +
                        " AND tenXe LIKE '%" + txtTenXe.Text.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count == 0)
                {
                    dgvXe.DataSource = null;
                    MessageBox.Show("Không có dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvXe.DataSource = dt;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


    }
}
