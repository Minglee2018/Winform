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
using System.Text.RegularExpressions;
using QuanLyBanXe.Database;

namespace QuanLyBanXe
{
    public partial class CapNhatThongTinKhachHang : Form
    {
        string userlogin;
        SqlConnection conn = ConnectDB.getDBConnection();
        public CapNhatThongTinKhachHang()
        {
            InitializeComponent();
        }
        public CapNhatThongTinKhachHang(string taiKhoan)
        {
            InitializeComponent();
            this.userlogin = taiKhoan;
        }
        int row;
        private void CapNhatThongTinKhachHang_Load(object sender, EventArgs e)
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
                dgvKhachHang.DataSource = dt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtTenKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ khách hàng không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(checkSoDienThoai(txtSoDienThoai.Text.Trim()) == false)
            {
                MessageBox.Show("Số điện thoại phải là số. (9-11 số)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "INSERT INTO KhachHang values (@maKH, @tenKH, @gioiTinh, @diaChi, @sdt)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text.Trim());
                cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text.Trim());
                if (rdbNam.Checked)
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nam");
                else
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nữ");
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                    MessageBox.Show("Mã khách hàng không được trùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinKhachHang_Load(sender, e);
            clearText();
        }

        private void clearText()
        {
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private Boolean checkSoDienThoai(String sdt)
        {
            Regex phonePattern = new Regex(@"^\d{9,11}$");
            if (!phonePattern.IsMatch(sdt))
                return false;
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ khách hàng không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkSoDienThoai(txtSoDienThoai.Text.Trim()) == false)
            {
                MessageBox.Show("Số điện thoại phải là số. (9-11 số)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "UPDATE KhachHang SET tenKH=@tenKH, gioiTinh=@gioiTinh, diaChi=@diaChi, " +
                    "sdt=@sdt WHERE maKH=@maKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text.Trim());
                cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text.Trim());
                if (rdbNam.Checked)
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nam");
                else
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nữ");
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinKhachHang_Load(sender, e);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if(row >= 0)
            {
                txtMaKhachHang.Text = dgvKhachHang.Rows[row].Cells[0].Value.ToString();
                txtTenKhachHang.Text = dgvKhachHang.Rows[row].Cells[1].Value.ToString();
                if (dgvKhachHang.Rows[row].Cells[2].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtDiaChi.Text = dgvKhachHang.Rows[row].Cells[3].Value.ToString();
                txtSoDienThoai.Text = dgvKhachHang.Rows[row].Cells[4].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "DELETE FROM KhachHang WHERE maKH=@maKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinKhachHang_Load(sender, e);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuNhanVien menuNhanVien = new MenuNhanVien(this.userlogin);
            menuNhanVien.Show();
            this.Hide();
        }
    }
}
