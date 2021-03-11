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
    public partial class CapNhatThongTinNhanVien : Form
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public CapNhatThongTinNhanVien()
        {
            InitializeComponent();
        }
        int row;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtTenNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkSoDienThoai(txtSoDienThoai.Text.Trim()) == false)
            {
                MessageBox.Show("Số điện thoại phải là số. (9-11 số)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtChucVu.Text.Trim() == "")
            {
                MessageBox.Show("Chức vụ không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "INSERT INTO NhanVien values (@maNV, @tenNV, @gioiTinh, @diaChi, @sdt" +
                    ", @chucVu, @ngayVaoLam, @matKhau)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNV", txtMaNhanVien.Text.Trim());
                cmd.Parameters.AddWithValue("@tenNV", txtTenNhanVien.Text.Trim());
                if (rdbNam.Checked)
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nam");
                else
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nữ");
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text.Trim());
                cmd.Parameters.AddWithValue("@chucVu", txtChucVu.Text.Trim());
                cmd.Parameters.AddWithValue("@ngayVaoLam", dtpNgayVaoLam.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@matKhau", txtMatKhau.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }catch(SqlException ex)
            {
                if(ex.Message.Contains("PRIMARY KEY"))
                    MessageBox.Show("Mã nhân viên không được trùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinNhanVien_Load(sender, e);
        }

        private Boolean checkSoDienThoai(String sdt)
        {
            Regex phonePattern = new Regex(@"^\d{9,11}$");
            if (!phonePattern.IsMatch(sdt))
                return false;
            return true;
        }

        private void CapNhatThongTinNhanVien_Load(object sender, EventArgs e)
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

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkSoDienThoai(txtSoDienThoai.Text.Trim()) == false)
            {
                MessageBox.Show("Số điện thoại phải là số. (9-11 số)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtChucVu.Text.Trim() == "")
            {
                MessageBox.Show("Chức vụ không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "UPDATE NhanVien SET tenNV=@tenNV, gioiTinh=@gioiTinh, diaChi=@diaChi, sdt=@sdt" +
                    ", chucVu=@chucVu, ngayVaoLam=@ngayVaoLam, matKhau=@matKhau WHERE maNV=@maNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNV", txtMaNhanVien.Text.Trim());
                cmd.Parameters.AddWithValue("@tenNV", txtTenNhanVien.Text.Trim());
                if (rdbNam.Checked)
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nam");
                else
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nữ");
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text.Trim());
                cmd.Parameters.AddWithValue("@chucVu", txtChucVu.Text.Trim());
                cmd.Parameters.AddWithValue("@ngayVaoLam", dtpNgayVaoLam.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@matKhau", txtMatKhau.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinNhanVien_Load(sender, e);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if(row >= 0)
            {
                txtMaNhanVien.Text = dgvNhanVien.Rows[row].Cells[0].Value.ToString();
                txtTenNhanVien.Text = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
                if (dgvNhanVien.Rows[row].Cells[2].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtDiaChi.Text = dgvNhanVien.Rows[row].Cells[3].Value.ToString();
                txtSoDienThoai.Text = dgvNhanVien.Rows[row].Cells[4].Value.ToString();
                txtChucVu.Text = dgvNhanVien.Rows[row].Cells[5].Value.ToString();
                dtpNgayVaoLam.Text = dgvNhanVien.Rows[row].Cells[6].Value.ToString();
                txtMatKhau.Text = dgvNhanVien.Rows[row].Cells[7].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String deleteString = "DELETE FROM HoaDonNhap WHERE maNV=@maNV";
                SqlCommand deleteConstraints = new SqlCommand(deleteString, conn);
                deleteConstraints.Parameters.AddWithValue("@maNV", txtMaNhanVien.Text.Trim());
                String sql = "DELETE FROM NhanVien WHERE maNV=@maNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNV", txtMaNhanVien.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatThongTinNhanVien_Load(sender, e);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuQuanLy menuQuanTri = new MenuQuanLy();
            menuQuanTri.Show();
            this.Hide();
        }
    }
}
