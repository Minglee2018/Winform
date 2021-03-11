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
    public partial class ChiTietHoaDonNhap : Form
    {
        string userLogin;
        SqlConnection conn = ConnectDB.getDBConnection();
        public ChiTietHoaDonNhap()
        {
            InitializeComponent();
            txtMaHoaDonNhap.Enabled = false;
            txtTongThanhTien.Enabled = false;
            txtThanhTien.Enabled = false;
            cboMaXe.Enabled = false;
        }
        public ChiTietHoaDonNhap(string taiKhoan)
        {
            InitializeComponent();
            txtMaHoaDonNhap.Enabled = false;
            txtTongThanhTien.Enabled = false;
            txtThanhTien.Enabled = false;
            cboMaXe.Enabled = false;
            this.userLogin = taiKhoan;
        }
        int row;
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            HoaDonNhap hdn = new HoaDonNhap(this.userLogin);
            hdn.Show();
            this.Hide();
        }

        private void ChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {
            txtMaHoaDonNhap.Text = HoaDonNhap.maHDN;
            LoadXe();
            LoadChiTietHoaDon();
            LoadComboBoxMaXe();
        }

        private void LoadComboBoxMaXe()
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
                cboMaXe.DataSource = dt;
                cboMaXe.DisplayMember = "maXe";
                cboMaXe.ValueMember = "maXe";
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietHoaDon()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT * FROM ChiTietHDNhap WHERE maHDN=@maHDN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHDN", HoaDonNhap.maHDN);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvChiTietHoaDonNhap.DataSource = dt;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadXe()
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
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTietHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            cboMaXe.Text = dgvChiTietHoaDonNhap.Rows[row].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvChiTietHoaDonNhap.Rows[row].Cells[2].Value.ToString();
            txtThueVAT.Text = dgvChiTietHoaDonNhap.Rows[row].Cells[3].Value.ToString();
            txtThanhTien.Text = dgvChiTietHoaDonNhap.Rows[row].Cells[4].Value.ToString();
            cboMaXe.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTenXe.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên xe để tìm kiếm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT * FROM Xe WHERE tenXe LIKE '%" + txtTenXe.Text.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                txtTenXe.Text = "";
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
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReLoadXe_Click(object sender, EventArgs e)
        {
            LoadXe();
        }

        private void btnTinhTongThanhTien_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT SUM(thanhTien) AS 'TongTien' FROM ChiTietHDNhap WHERE maHDN=@maHDN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHDN", HoaDonNhap.maHDN);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DataRow drow = dt.Rows[0];
                txtTongThanhTien.Text = drow[0].ToString();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "DELETE FROM ChiTietHDNhap WHERE maHDN=@maHDN AND maXe=@maXe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHDN", txtMaHoaDonNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@maXe", cboMaXe.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ChiTietHoaDonNhap_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cboMaXe.Enabled = true;
            if (txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong;
            if(Int32.TryParse(txtSoLuong.Text.Trim(), out soLuong) == false)
            {
                MessageBox.Show("Số lượng phải là số", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtThueVAT.Text.Trim() == "")
            {
                MessageBox.Show("Thuế VAT không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            float thueVAT;
            if(float.TryParse(txtThueVAT.Text.Trim(), out thueVAT) == false)
            {
                MessageBox.Show("Thuế VAT phải là số", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(thueVAT < 0 || thueVAT > 1)
                {
                    MessageBox.Show("Thuế VAT phải từ 0 -> 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            String donGiaString = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "select giaNhap from Xe where maXe = @maXe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maXe", cboMaXe.SelectedValue.ToString());
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DataRow drow = dt.Rows[0];
                donGiaString = drow[0].ToString();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            float donGia = float.Parse(donGiaString);
            float tongTien = tinhTongTien(soLuong, donGia, thueVAT);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "INSERT INTO ChiTietHDNhap VALUES (@maHDN, @maXe, @soLuong, @thueVAT, @thanhTien)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHDN", HoaDonNhap.maHDN);
                cmd.Parameters.AddWithValue("@maXe", cboMaXe.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@soLuong", soLuong);
                cmd.Parameters.AddWithValue("@thueVAT", thueVAT);
                cmd.Parameters.AddWithValue("@thanhTien", tongTien);
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                if(ex.Message.Contains("PRIMARY KEY"))
                {
                    MessageBox.Show("Khóa chính không được trùng.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ChiTietHoaDonNhap_Load(sender, e);
            clearText();
        }

        private float tinhTongTien(int soLuong,float donGia,float thueVAT)
        {
            return (soLuong * donGia) + ((soLuong * donGia) * thueVAT);
        }

        private void clearText()
        {
            txtSoLuong.Text = "";
            txtThueVAT.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong;
            if (Int32.TryParse(txtSoLuong.Text.Trim(), out soLuong) == false)
            {
                MessageBox.Show("Số lượng phải là số", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtThueVAT.Text.Trim() == "")
            {
                MessageBox.Show("Thuế VAT không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            float thueVAT;
            if (float.TryParse(txtThueVAT.Text.Trim(), out thueVAT) == false)
            {
                MessageBox.Show("Thuế VAT phải là số", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (thueVAT < 0 || thueVAT > 1)
                {
                    MessageBox.Show("Thuế VAT phải từ 0 -> 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            String donGiaString = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "select giaNhap from Xe where maXe = @maXe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maXe", cboMaXe.SelectedValue.ToString());
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DataRow drow = dt.Rows[0];
                donGiaString = drow[0].ToString();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            float donGia = float.Parse(donGiaString);
            float tongTien = tinhTongTien(soLuong, donGia, thueVAT);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "UPDATE ChiTietHDNhap SET soLuong=@soLuong, thueVAT=@thueVAT, thanhTien=@thanhTien " +
                    "WHERE maHDN=@maHDN AND maXe=@maXe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHDN", HoaDonNhap.maHDN);
                cmd.Parameters.AddWithValue("@maXe", cboMaXe.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@soLuong", soLuong);
                cmd.Parameters.AddWithValue("@thueVAT", thueVAT);
                cmd.Parameters.AddWithValue("@thanhTien", tongTien);
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                {
                    MessageBox.Show("Khóa chính không được trùng.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ChiTietHoaDonNhap_Load(sender, e);
            clearText();
        }
    }
}
