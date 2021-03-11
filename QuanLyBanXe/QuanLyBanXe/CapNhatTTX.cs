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
    public partial class CapNhatTTX : Form
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public CapNhatTTX()
        {
            InitializeComponent();
        }
        private void CapNhatTTX_Load(object sender, EventArgs e)
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
                dgvCapNhatTTX.DataSource = dt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btThem_Click(object sender, EventArgs e)
        {   
            if(txtMaXe.Text.Trim()=="")
            {
                MessageBox.Show("Mã xe không được để trống");
                return;
            }
            if(cbMaLoaiXe.SelectedIndex == -1)
            {
                MessageBox.Show("Mã loại xe không được để trống:");
                return;
            }
            if(cbMaNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống:");
                return;
            }
            if(txtTenXe.Text.Trim()=="")
            {
                MessageBox.Show("Tên xe không được để trống:");
                return;
            }
            int a;
            if(!Int32.TryParse(txtGiaNhap.Text.Trim(),out a))
            {
                MessageBox.Show("Giá nhập phải là số");
                return;
            }
            if(a<=0)
            {
                MessageBox.Show("Giá nhập phải dương");
            }
            int b;
            if (!Int32.TryParse(txtGiaBan.Text.Trim(), out b))
            {
                MessageBox.Show("Giá bán phải là số");
                return;
            }
            if (b <= 0)
            {
                MessageBox.Show("Giá bán phải dương");
            }
            float c;
            if(!float.TryParse(txtDungTich.Text.Trim(),out c))
            {
                MessageBox.Show("Dung tích phải là số");
                return;
            }
            if(c<=0)
            {
                MessageBox.Show("Dung tích phải dương");
                return;
            }
            if(txtTinhTrang.Text.Trim() == "")
            {
                MessageBox.Show("Trạng thái không được trôngs");
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "INSERT INTO XE values(@maXe,@maLoaiXe,@maNCC,@tenXe," +
                    "@giaNhap,@giaBan,@mau,@dungTich,@tinhTrang)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maXe",txtMaXe.Text.Trim());
                cmd.Parameters.AddWithValue("@maLoaiXe",cbMaLoaiXe.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@maNCC",cbMaNCC.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tenXe",txtTenXe.Text.Trim());
                cmd.Parameters.AddWithValue("@giaNhap", a);
                cmd.Parameters.AddWithValue("@giaBan",b);
                cmd.Parameters.AddWithValue("@mau",txtMau.Text.Trim());
                cmd.Parameters.AddWithValue("@dungTich",c);
                cmd.Parameters.AddWithValue("@tinhTrang",txtTinhTrang.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CapNhatTTX_Load(sender, e);
        }

        private void btTroVe_Click(object sender, EventArgs e)
        {
            MenuQuanLy frmQuanLy = new MenuQuanLy();
            frmQuanLy.Show();
            this.Hide();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtMaXe.Text.Trim() == "")
            {
                MessageBox.Show("Mã xe không được để trống");
                return;
            }
            if (cbMaLoaiXe.SelectedIndex == -1)
            {
                MessageBox.Show("Mã loại xe không được để trống:");
                return;
            }
            if (cbMaNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống:");
                return;
            }
            if (txtTenXe.Text.Trim() == "")
            {
                MessageBox.Show("Tên xe không được để trống:");
                return;
            }
            int a;
            if (!Int32.TryParse(txtGiaNhap.Text.Trim(), out a))
            {
                MessageBox.Show("Giá nhập phải là số");
                return;
            }
            if (a <= 0)
            {
                MessageBox.Show("Giá nhập phải dương");
            }
            int b;
            if (!Int32.TryParse(txtGiaBan.Text.Trim(), out b))
            {
                MessageBox.Show("Giá bán phải là số");
                return;
            }
            if (b <= 0)
            {
                MessageBox.Show("Giá bán phải dương");
            }
            float c;
            if (!float.TryParse(txtDungTich.Text.Trim(), out c))
            {
                MessageBox.Show("Dung tích phải là số");
                return;
            }
            if (c <= 0)
            {
                MessageBox.Show("Dung tích phải dương");
                return;
            }
            if (txtTinhTrang.Text.Trim() == "")
            {
                MessageBox.Show("Trạng thái không được trôngs");
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "UPDATE Xe SET maLoaiXe=@maLoaiXe, maNCC=@maNCC,tenXe=@tenXe," +
                    "giaNhap=@giaNhap,giaBan=@giaBan,mau=@mau,dungTich=@dungTich,tinhTrang=@tinhTrang" +
                    " WHERE maXe=@maXe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maXe", txtMaXe.Text.Trim());
                cmd.Parameters.AddWithValue("@maLoaiXe", cbMaLoaiXe.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@maNCC", cbMaNCC.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tenXe", txtTenXe.Text.Trim());
                cmd.Parameters.AddWithValue("@giaNhap", a);
                cmd.Parameters.AddWithValue("@giaBan", b);
                cmd.Parameters.AddWithValue("@mau", txtMau.Text.Trim());
                cmd.Parameters.AddWithValue("@dungTich", c);
                cmd.Parameters.AddWithValue("@tinhTrang", txtTinhTrang.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CapNhatTTX_Load(sender, e);
        }
        int row;
        private void dgvCapNhatTTX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if(row>=0)
            {
                txtMaXe.Text = dgvCapNhatTTX.Rows[row].Cells[0].Value.ToString();
                cbMaLoaiXe.Text = dgvCapNhatTTX.Rows[row].Cells[1].Value.ToString();
                cbMaNCC.Text = dgvCapNhatTTX.Rows[row].Cells[2].Value.ToString();
                txtTenXe.Text = dgvCapNhatTTX.Rows[row].Cells[3].Value.ToString();
                txtGiaNhap.Text = dgvCapNhatTTX.Rows[row].Cells[4].Value.ToString();
                txtGiaBan.Text = dgvCapNhatTTX.Rows[row].Cells[5].Value.ToString();
                txtMau.Text = dgvCapNhatTTX.Rows[row].Cells[6].Value.ToString();
                txtDungTich.Text = dgvCapNhatTTX.Rows[row].Cells[7].Value.ToString();
                txtTinhTrang.Text = dgvCapNhatTTX.Rows[row].Cells[8].Value.ToString();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "DELETE FROM Xe WHERE maXe=@maXe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maXe", txtMaXe.Text.Trim());
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatTTX_Load(sender, e);
        }
    }
}
