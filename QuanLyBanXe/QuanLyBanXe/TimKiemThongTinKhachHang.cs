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
    public partial class TimKiemThongTinKhachHang : Form
    {
        string userlogin;
        SqlConnection conn = ConnectDB.getDBConnection();
        public TimKiemThongTinKhachHang()
        {
            InitializeComponent();
        }
        public TimKiemThongTinKhachHang(string taiKhoan)
        {
            InitializeComponent();
            this.userlogin = taiKhoan;
        }

        private void btnHienHet_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT * FROM KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTimKhachHang.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuNhanVien menuNhanVien = new MenuNhanVien(this.userlogin);
            menuNhanVien.Show();
            this.Hide();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtMaKhachHang.Text.Trim() == "" && txtTenKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập vào MaKH, TenKH.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql;
                if(txtMaKhachHang.Text.Trim() != "" && txtTenKhachHang.Text.Trim() == "")
                {
                    sql = "SELECT * FROM KhachHang WHERE maKH LIKE '" + txtMaKhachHang.Text.Trim() + "%'";
                }
                else if(txtMaKhachHang.Text.Trim() == "" && txtTenKhachHang.Text.Trim() != "")
                {
                    sql = "SELECT * FROM KhachHang WHERE tenKH LIKE '%" + txtTenKhachHang.Text.Trim() + "%'";
                }
                else
                {
                    sql = "SELECT * FROM KhachHang WHERE maKH LIKE '" + txtMaKhachHang.Text.Trim() + "%'" +
                        " AND tenKH LIKE '%" + txtTenKhachHang.Text.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if(dt.Rows.Count == 0)
                {
                    dgvTimKhachHang.DataSource = null;
                    MessageBox.Show("Không có dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvTimKhachHang.DataSource = dt;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
