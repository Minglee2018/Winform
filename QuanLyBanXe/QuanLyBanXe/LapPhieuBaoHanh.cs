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
    public partial class LapPhieuBaoHanh : Form
    {
        private PhieuBaoHanhDAO phieuBHDao = new PhieuBaoHanhDAO();
        private String userLogin;
        private int rowPBH = -1, rowPX = -1;
        public LapPhieuBaoHanh()
        {
            InitializeComponent();
        }
        public LapPhieuBaoHanh(String userLogin) : this()
        {
            this.userLogin = userLogin;
        }
        public void loadDSPhieuXuat()
        {
            try
            {
                dgvPhieuXuat.DataSource = phieuBHDao.getDSPhieuXuatTheoNV(userLogin);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadDSPhieuBH()
        {
            try
            {
                dgvPhieuBH.DataSource = phieuBHDao.getDSPhieuBHTheoNV(userLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void resetAll()
        {
            rowPBH = -1;
            rowPX = -1;
            txtMaPhieuBH.Text = "";
            txtMaXe.Text = "";
            txtMaKH.Text = "";
            cmbTGBH.SelectedIndex = -1;
        }
        private void LapPhieuBaoHanh_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = userLogin;
            loadDSPhieuXuat();
            loadDSPhieuBH();
            dgvPhieuXuat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowPX == -1)
                {
                    MessageBox.Show("Vui lòng chọn phiếu xuất có xe cần lập phiếu bảo hành!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String maPhieuBH = txtMaPhieuBH.Text.Trim();
                String TGBH = cmbTGBH.Text;
                String maNV = txtMaNV.Text.Trim();
                String maKH = txtMaKH.Text.Trim();
                String maXe = txtMaXe.Text.Trim();
                DateTime ngayMua = dtpNgayMua.Value;
                if (maPhieuBH.Equals(""))
                {
                    MessageBox.Show("Mã phiếu bảo hành không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TGBH.Equals(""))
                {
                    MessageBox.Show("TGBH phải được chọn.!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (phieuBHDao.checkExistMaPhieuBH(maPhieuBH))
                {
                    MessageBox.Show("Mã phiếu BH đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                phieuBHDao.createPhieuBH(maPhieuBH, maNV, maKH, maXe, TGBH, ngayMua);
                resetAll();
                loadDSPhieuBH();
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowPBH == -1)
                {
                    MessageBox.Show("Vui lòng chọn phiếu xuất có xe cần sửa phiếu bảo hành!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String maPhieuBH = txtMaPhieuBH.Text.Trim();
                String TGBH = cmbTGBH.Text;
                String maNV = txtMaNV.Text.Trim();
                String maKH = txtMaKH.Text.Trim();
                String maXe = txtMaXe.Text.Trim();
                DateTime ngayMua = dtpNgayMua.Value;
                if (maPhieuBH.Equals(""))
                {
                    MessageBox.Show("Mã phiếu bảo hành không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TGBH.Equals(""))
                {
                    MessageBox.Show("TGBH phải được chọn.!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!maPhieuBH.Equals(dgvPhieuBH.Rows[rowPBH].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Không thể sửa mã phiếu BH. Thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                phieuBHDao.updatePhieuBH(maPhieuBH, maNV, maKH, maXe, TGBH, ngayMua);
                resetAll();
                loadDSPhieuBH();
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
                if(rowPBH == -1)
                {
                    MessageBox.Show("Vui lòng chọn phiếu bảo hành cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String maPhieuBH = txtMaPhieuBH.Text.Trim();
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dr == DialogResult.Yes)
                {
                    phieuBHDao.deletePhieuBH(maPhieuBH);
                    resetAll();
                    loadDSPhieuBH();
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowPX = e.RowIndex;
            if(rowPX != -1)
            {
                txtMaXe.Text = dgvPhieuXuat.Rows[rowPX].Cells[1].Value.ToString();
                txtMaNV.Text = dgvPhieuXuat.Rows[rowPX].Cells[2].Value.ToString();
                txtMaKH.Text = dgvPhieuXuat.Rows[rowPX].Cells[3].Value.ToString();
                dtpNgayMua.Text = dgvPhieuXuat.Rows[rowPX].Cells[4].Value.ToString();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MenuNhanVien frmMenuNV = new MenuNhanVien(this.userLogin);
            this.Hide();
            frmMenuNV.Show();
        }

        private void dgvPhieuBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowPBH = e.RowIndex;
            if (rowPBH != -1)
            {
                txtMaPhieuBH.Text = dgvPhieuBH.Rows[rowPBH].Cells[0].Value.ToString();
                txtMaNV.Text = dgvPhieuBH.Rows[rowPBH].Cells[1].Value.ToString();
                txtMaKH.Text = dgvPhieuBH.Rows[rowPBH].Cells[2].Value.ToString();
                txtMaXe.Text = dgvPhieuBH.Rows[rowPBH].Cells[3].Value.ToString();
                cmbTGBH.SelectedItem = dgvPhieuBH.Rows[rowPBH].Cells[4].Value.ToString();
                dtpNgayMua.Text = dgvPhieuBH.Rows[rowPBH].Cells[5].Value.ToString();
            }
        }
    }
}
