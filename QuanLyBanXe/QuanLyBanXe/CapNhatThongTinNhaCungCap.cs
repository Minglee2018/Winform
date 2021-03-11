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
    public partial class CapNhatThongTinNhaCungCap : Form
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public CapNhatThongTinNhaCungCap()
        {
            InitializeComponent();
        }
        int row;
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuQuanLy menuQL = new MenuQuanLy();
            menuQL.Show();
            this.Hide();
        }

        private void CapNhatThongTinNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT * FROM NhaCungCap";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhaCungCap.DataSource = dt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if(row >= 0)
            {
                txtMaNCC.Text = dgvNhaCungCap.Rows[row].Cells[0].Value.ToString();
                txtTenNCC.Text = dgvNhaCungCap.Rows[row].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNhaCungCap.Rows[row].Cells[2].Value.ToString();
                txtSoDienThoai.Text = dgvNhaCungCap.Rows[row].Cells[3].Value.ToString();
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "DELETE FROM NhaCungCap WHERE maNCC=@maNCC";
                SqlCommand cmdNhaCungCap = new SqlCommand(sql, conn);
                cmdNhaCungCap.Parameters.AddWithValue("@maNCC", txtMaNCC.Text.Trim());
                cmdNhaCungCap.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinNhaCungCap_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Mã NCC không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Tên NCC không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ NCC không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                String sql = "INSERT INTO NhaCungCap values (@maNCC, @tenNCC, @diaChi, @sdt)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text.Trim());
                cmd.Parameters.AddWithValue("@tenNCC", txtTenNCC.Text.Trim());
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                    MessageBox.Show("Mã nhân viên không được trùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinNhaCungCap_Load(sender, e);
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
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Mã NCC không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Tên NCC không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ NCC không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                String sql = "UPDATE NhaCungCap SET tenNCC=@tenNCC, diaChi=@diaChi, sdt=@sdt WHERE maNCC=@maNCC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text.Trim());
                cmd.Parameters.AddWithValue("@tenNCC", txtTenNCC.Text.Trim());
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                    MessageBox.Show("Mã nhân viên không được trùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinNhaCungCap_Load(sender, e);
        }
    }
}
