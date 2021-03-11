using QuanLyBanXe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanXe
{
    public partial class HoaDonXuat : Form
    {
        private HoaDonXuatDAO hoaDonXuatDao = new HoaDonXuatDAO();
        private String userLogin;
        private int rowKH = -1, rowHD = -1;
        public HoaDonXuat()
        {
            InitializeComponent();
        }
        public HoaDonXuat(String userLogin) : this()
        {
            this.userLogin = userLogin;
            txtMaNV.Text = this.userLogin;
        }
        public void loadDSKhachHang()
        {
            try
            {
                dgvKhachHang.DataSource = hoaDonXuatDao.getDSKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadDSHoaDon()
        {
            try
            {
                dgvHoaDon.DataSource = hoaDonXuatDao.getDSHoaDonTheoNV(userLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void resetAll()
        {
            rowHD = -1;
            rowKH = -1;
            txtMaHDX.Text = "";
            txtMaKH.Text = "";
            txtTimKiem.Text = "";
            loadDSHoaDon();
            loadDSKhachHang();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAll();
        }
        private void HoaDonXuat_Load(object sender, EventArgs e)
        {
            loadDSKhachHang();
            loadDSHoaDon();
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                String key = txtTimKiem.Text.Trim();
                loadDSKhachHang();
                if (key.Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvKhachHang.DataSource = hoaDonXuatDao.getDSKhachHangTheoTen(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowKH == -1)
                {
                    MessageBox.Show("Vui lòng nhập chọn khách hàng muốn lập hóa đơn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String maHD = txtMaHDX.Text.Trim();
                String maNV = txtMaNV.Text.Trim();
                String maKH = txtMaKH.Text.Trim();
                DateTime ngayXuat = dtpNgayXuat.Value;
                if (maHD.Equals(""))
                {
                    MessageBox.Show("Mã hóa đơn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (hoaDonXuatDao.checkExistHoaDon(maHD))
                {
                    MessageBox.Show("Hóa đơn xuất đã tồn tại! Không thể thêm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                resetAll();
                hoaDonXuatDao.createHoaDon(maHD, maNV, maKH, ngayXuat);
                loadDSHoaDon();
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowHD == -1)
                {
                    MessageBox.Show("Vui lòng nhập chọn hóa đơn muốn sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String maHD = txtMaHDX.Text.Trim();
                String maNV = txtMaNV.Text.Trim();
                String maKH = txtMaKH.Text.Trim();
                DateTime ngayXuat = dtpNgayXuat.Value;
                if (maHD.Equals(""))
                {
                    MessageBox.Show("Mã hóa đơn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!maHD.Equals(dgvHoaDon.Rows[rowHD].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Không thể sửa mã hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                resetAll();
                hoaDonXuatDao.updateHoaDon(maHD, maNV, maKH, ngayXuat);
                loadDSHoaDon();
                MessageBox.Show("Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuNhanVien frmMenuNV = new MenuNhanVien(this.userLogin);
            frmMenuNV.Show();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowHD == -1)
                {
                    MessageBox.Show("Vui lòng nhập chọn hóa đơn muốn xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    hoaDonXuatDao.deleteChiTietHoaDon(txtMaHDX.Text.Trim());
                    hoaDonXuatDao.deleteHoaDon(txtMaHDX.Text.Trim());
                    loadDSHoaDon();
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnLapChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if(rowHD == -1)
                {
                    MessageBox.Show("Vui lòng nhập chọn hóa đơn muốn lập chi tiết!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ChiTietHoaDonXuat frmChiTietHDXuat = new ChiTietHoaDonXuat(txtMaHDX.Text.Trim(), userLogin);
                this.Hide();
                frmChiTietHDXuat.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowKH = e.RowIndex;
            if (rowKH != -1)
            {
                txtMaKH.Text = dgvKhachHang.Rows[rowKH].Cells[0].Value.ToString();
            }
        }
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowHD = e.RowIndex;
            if (rowHD != -1)
            {
                txtMaHDX.Text = dgvHoaDon.Rows[rowHD].Cells[0].Value.ToString();
                txtMaNV.Text = dgvHoaDon.Rows[rowHD].Cells[1].Value.ToString();
                txtMaKH.Text = dgvHoaDon.Rows[rowHD].Cells[2].Value.ToString();
                dtpNgayXuat.Text = dgvHoaDon.Rows[rowHD].Cells[3].Value.ToString();
            }
        }
    }
}
