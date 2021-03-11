using QuanLyBanXe.DAO;
using QuanLyBanXe.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanXe
{
    public partial class DangNhap : Form
    {
        SqlConnection conn = ConnectDB.getDBConnection();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                String taiKhoan = txtTaiKhoan.Text.Trim();
                String matKhau = txtMatKhau.Text.Trim();
                Single role;
                if (taiKhoan.Equals("") || matKhau.Equals(""))
                {
                    MessageBox.Show("Vui lòng không để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rdNhanVien.Checked)
                    role = 0;
                else role = 1;
                if (role == 0)
                {
                    NhanVienDAO nhanVienDao = new NhanVienDAO();
                    if (nhanVienDao.checkExistAccNV(taiKhoan, matKhau))
                    {
                        this.Hide();
                        MenuNhanVien frmMenuNV = new MenuNhanVien(taiKhoan);
                        frmMenuNV.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.Thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                if (role == 1)
                {
                    AdminDAO adminDao = new AdminDAO();
                    if (adminDao.checkExistAccAdmin(taiKhoan, matKhau))
                    {
                        this.Hide();
                        MenuQuanLy frmMenuQL = new MenuQuanLy(taiKhoan);
                        frmMenuQL.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.Thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
    }
}
