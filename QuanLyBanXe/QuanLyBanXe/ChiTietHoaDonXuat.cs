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
    public partial class ChiTietHoaDonXuat : Form
    {
        private String maHDX, userLogin;
        private ChiTietHoaDonXuatDAO chiTietHDXDao = new ChiTietHoaDonXuatDAO();
        private int rowXe = -1, rowCTHD = -1;
        public ChiTietHoaDonXuat()
        {
            InitializeComponent();
        }
        public ChiTietHoaDonXuat(String maHDX, String userLogin) : this()
        {
            this.maHDX = maHDX;
            this.userLogin = userLogin;
        }
        public void loadDSXe()
        {
            try
            {
                dgvXe.DataSource = chiTietHDXDao.getDSXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadDSChiTietHDX()
        {
            try
            {
                dgvChiTietHDX.DataSource = chiTietHDXDao.getDSXeTheoMaHD(maHDX);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Double TinhThanhTien(Int32 soLuong, Double giaBan, Double thueVAT)
        {
            return soLuong * giaBan + (soLuong * giaBan) * thueVAT;
        }
        public void resetAll()
        {
            rowXe = -1;
            rowCTHD = -1;
            txtGiaBan.Text = "";
            txtMaXe.Text = "";
            txtSoLuong.Text = "";
            txtThueVAT.Text = "";
            txtTimKiem.Text = "";
            txtTongThanhTien.Text = "";
        }

        private void ChiTietHoaDonXuat_Load(object sender, EventArgs e)
        {
            txtMaHDX.Text = maHDX;
            loadDSXe();
            loadDSChiTietHDX();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                String key = txtTimKiem.Text.Trim();
                if (key.Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập tên xe cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvXe.DataSource = chiTietHDXDao.getDSXeTheoTen(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowXe == -1)
                {
                    MessageBox.Show("Vui lòng chọn xe muốn nhập chi tiết hóa đơn.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String maHDX = txtMaHDX.Text.Trim();
                String maXe = txtMaXe.Text.Trim();
                Double giaBan = Double.Parse(txtGiaBan.Text.Trim());
                String sl = txtSoLuong.Text.Trim();
                String thue = txtThueVAT.Text.Trim();
                Int32 soLuong = 0;
                Double thueVAT = 0;
                Double thanhTien = 0;
                if (sl.Equals("") || thue.Equals(""))
                {
                    MessageBox.Show("Không được để trống. Nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    soLuong = Int32.Parse(sl);
                }
                catch (Exception)
                {
                    MessageBox.Show("Số lượng không đúng định dạng.Số lượng phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    thueVAT = Double.Parse(thue);
                }
                catch (Exception)
                {
                    MessageBox.Show("Thuế VAT không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (chiTietHDXDao.checkExistXeXuat(maHDX, maXe))
                {
                    MessageBox.Show("Mã xe đã tồn tại trong DS xe xuất.Không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thanhTien = TinhThanhTien(soLuong, giaBan, thueVAT);
                chiTietHDXDao.insertChiTietHDX(maHDX, maXe, soLuong, thueVAT, thanhTien);
                resetAll();
                loadDSChiTietHDX();
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            HoaDonXuat frmHDX = new HoaDonXuat(userLogin);
            this.Hide();
            frmHDX.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowCTHD == -1)
                {
                    MessageBox.Show("Vui lòng chọn xe xuất muốn sửa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String maHDX = txtMaHDX.Text.Trim();
                String maXe = txtMaXe.Text.Trim();
                Double giaBan = Double.Parse(txtGiaBan.Text.Trim());
                String sl = txtSoLuong.Text.Trim();
                String thue = txtThueVAT.Text.Trim();
                Int32 soLuong = 0;
                Double thueVAT = 0;
                Double thanhTien = 0;
                if (sl.Equals("") || thue.Equals(""))
                {
                    MessageBox.Show("Không được để trống. Nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    soLuong = Int32.Parse(sl);
                }
                catch (Exception)
                {
                    MessageBox.Show("Số lượng không đúng định dạng.Số lượng phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    thueVAT = Double.Parse(thue);
                }
                catch (Exception)
                {
                    MessageBox.Show("Thuế VAT không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!dgvChiTietHDX.Rows[rowCTHD].Cells[0].Value.ToString().Equals(maXe))
                {
                    MessageBox.Show("Không thể thay đổi xe xuất. Thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thanhTien = TinhThanhTien(soLuong, giaBan, thueVAT);
                chiTietHDXDao.updateChiTietHDX(maHDX, maXe, soLuong, thueVAT, thanhTien);
                resetAll();
                loadDSChiTietHDX();
                MessageBox.Show("Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowCTHD == -1)
                {
                    MessageBox.Show("Vui lòng chọn xe xuất muốn xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dr == DialogResult.Yes)
                {
                    chiTietHDXDao.deleteChiTietHDX(txtMaHDX.Text.Trim(), txtMaXe.Text.Trim());
                    resetAll();
                    loadDSChiTietHDX();
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTinhTongThanhTien_Click(object sender, EventArgs e)
        {
            try
            {
                txtTongThanhTien.Text = chiTietHDXDao.getTongThanhTien(txtMaHDX.Text.Trim()) + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvChiTietHDX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowCTHD = e.RowIndex;
            if(rowCTHD != -1)
            {
                txtMaXe.Text = dgvChiTietHDX.Rows[rowCTHD].Cells[0].Value.ToString();
                txtSoLuong.Text = dgvChiTietHDX.Rows[rowCTHD].Cells[2].Value.ToString();
                txtGiaBan.Text = dgvChiTietHDX.Rows[rowCTHD].Cells[3].Value.ToString(); ;
                txtThueVAT.Text = dgvChiTietHDX.Rows[rowCTHD].Cells[4].Value.ToString();
            }
        }
        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowXe = e.RowIndex;
            if (rowXe != -1)
            {
                txtMaXe.Text = dgvXe.Rows[rowXe].Cells[0].Value.ToString();
                txtGiaBan.Text = dgvXe.Rows[rowXe].Cells[5].Value.ToString();
            }
        }
    }
}
