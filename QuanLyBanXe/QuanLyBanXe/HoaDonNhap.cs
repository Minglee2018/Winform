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
    public partial class HoaDonNhap : Form
    {
        string userLogin;
        SqlConnection conn = ConnectDB.getDBConnection();
        public static String maHDN;
        
        public HoaDonNhap()
        {
            InitializeComponent();
            txtMaNV.Enabled = false;
            txtMaNV.Text = "NV01";
        }
        public HoaDonNhap(string taiKhoan)
        {
            InitializeComponent();
            txtMaNV.Enabled = false;
            this.userLogin = taiKhoan;
            txtMaNV.Text = taiKhoan;
        }
        int row;
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuNhanVien menuNhanVien = new MenuNhanVien(this.userLogin);
            menuNhanVien.Show();
            this.Hide();
        }

        private void HoaDonNhap_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sqlNhaCungCap = "SELECT * FROM NhaCungCap";
                SqlDataAdapter daNCC = new SqlDataAdapter(sqlNhaCungCap, conn);
                String sqlHoaDonNhap = "SELECT * FROM HoaDonNhap WHERE maNV=@maNV";
                SqlCommand cmd = new SqlCommand(sqlHoaDonNhap, conn);
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvHoaDonNhap.DataSource = dt;
                String sqlComboBoxNCC = "SELECT * FROM NhaCungCap";
                SqlDataAdapter daComboBoxNCC = new SqlDataAdapter(sqlComboBoxNCC, conn);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataTable dtNCC = new DataTable();
                daNCC.Fill(dtNCC);
                dgvNhaCungCap.DataSource = dtNCC;
                DataTable dtComboBoxNCC = new DataTable();
                daComboBoxNCC.Fill(dtComboBoxNCC);
                this.cboMaNCC.DataSource = dtComboBoxNCC;
                this.cboMaNCC.DisplayMember = "maNCC";
                this.cboMaNCC.ValueMember = "maNCC";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Nhập tên NCC để tìm kiếm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT * FROM NhaCungCap WHERE tenNCC LIKE '%" + txtTenNCC.Text.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count == 0)
                {
                    dgvNhaCungCap.DataSource = null;
                    MessageBox.Show("Không có dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvNhaCungCap.DataSource = dt;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "UPDATE HoaDonNhap SET maNCC=@maNCC, ngayNhap=@ngayNhap, maNV=@maNV WHERE maHDN=@maHDN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNCC", cboMaNCC.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@ngayNhap", dtpNgayNhap.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@maHDN", txtMaHoaDonNhap.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HoaDonNhap_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaHoaDonNhap.Text.Trim() == "")
            {
                MessageBox.Show("Mã hóa đơn không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "INSERT INTO HoaDonNhap VALUES (@maHDN, @maNV, @maNCC, @ngayNhap)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHDN", txtMaHoaDonNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@maNCC", cboMaNCC.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@ngayNhap", dtpNgayNhap.Value.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }catch(SqlException ex)
            {
                if(ex.Message.Contains("PRIMARY KEY"))
                {
                    MessageBox.Show("Mã hóa đơn nhập không được trùng nhau. NV khác đã thêm MaHD này.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HoaDonNhap_Load(sender, e);
            clearText();
        }

        private void clearText()
        {
            txtMaHoaDonNhap.Text = "";
            cboMaNCC.Text = "";
        }  

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "DELETE FROM HoaDonNhap WHERE maHDN=@maHDN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHDN", txtMaHoaDonNhap.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HoaDonNhap_Load(sender, e);
        }

        private void btnLapChiTietDonHang_Click(object sender, EventArgs e)
        {
            maHDN = txtMaHoaDonNhap.Text.Trim();
            ChiTietHoaDonNhap cthdn = new ChiTietHoaDonNhap(this.userLogin);
            cthdn.Show();
            this.Hide();
        }

        private void btnReLoadNCC_Click(object sender, EventArgs e)
        {
            String sqlNhaCungCap = "SELECT * FROM NhaCungCap";
            SqlDataAdapter daNCC = new SqlDataAdapter(sqlNhaCungCap, conn);
            DataTable dtNCC = new DataTable();
            daNCC.Fill(dtNCC);
            dgvNhaCungCap.DataSource = dtNCC;
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if(row >= 0)
            {
                txtMaHoaDonNhap.Text = dgvHoaDonNhap.Rows[row].Cells[0].Value.ToString();
                txtMaNV.Text = dgvHoaDonNhap.Rows[row].Cells[1].Value.ToString();
                cboMaNCC.Text = dgvHoaDonNhap.Rows[row].Cells[2].Value.ToString();
                dtpNgayNhap.Text = dgvHoaDonNhap.Rows[row].Cells[3].Value.ToString();
            }

        }
    }
}
