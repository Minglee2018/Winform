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
    public partial class TimKiemThongTinNhanVien : Form
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public TimKiemThongTinNhanVien()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuQuanLy menuQuanLy = new MenuQuanLy();
            menuQuanLy.Show();
            this.Hide();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" && txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập vào MaNV, TenNV.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql;
                if (txtMaNV.Text.Trim() != "" && txtTenNV.Text.Trim() == "")
                {
                    sql = "SELECT * FROM NhanVien WHERE maNV LIKE '" + txtMaNV.Text.Trim() + "%'";
                }
                else if (txtMaNV.Text.Trim() == "" && txtTenNV.Text.Trim() != "")
                {
                    sql = "SELECT * FROM NhanVien WHERE tenNV LIKE '%" + txtTenNV.Text.Trim() + "%'";
                }
                else
                {
                    sql = "SELECT * FROM NhanVien WHERE maNV LIKE '" + txtMaNV.Text.Trim() + "%'" +
                        " AND tenNV LIKE '%" + txtTenNV.Text.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count == 0)
                {
                    dgvNhanVien.DataSource = null;
                    MessageBox.Show("Không có dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvNhanVien.DataSource = dt;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnHienHet_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT * FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiemThongTinNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
