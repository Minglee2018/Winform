using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Model;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.View
{
    public partial class DatPhongScreen : Form
    {
        private Entity.Phong phong;
        public DatPhongScreen()
        {
            InitializeComponent();
            cmbLoaiPhong.Text = "Tất cả";
            cmbGioiTinh.Text = "Nam";
        }

       

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DatPhongScreen_Load(object sender, EventArgs e)
        {
            Model.LoadUtil.taiDuLieuVaoBang(dtgThongTinPhong,"Phong");
        }

      

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
             Model.ExcuteAdd.DatPhong(cmbLoaiPhong, dtpNgayDat,
                 txtSoPhong,txtGia, txtTenKH, txtCMT, txtDiaChi,
                 txtSDT, cmbLoaiPhong, dtpNgaySinh, phong );

            Model.LoadUtil.taiDuLieuVaoBang(dtgThongTinPhong, "Phong");
        }

      

        private void dtgThongTinPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*txtSoPhong.Text = dtgThongTinPhong.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtGia.Text = dtgThongTinPhong.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            cmbLoaiPhong.Text = dtgThongTinPhong.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            Entity.Phong p = new Entity.Phong(int.Parse(txtSoPhong.Text),cmbLoaiPhong.Text,
                                Boolean.Parse(dtgThongTinPhong.Rows[e.RowIndex].Cells[2].Value.ToString()), 
                                Double.Parse(txtGia.Text));
            phong = p;*/
            CellClickTableContent.cellClickTableDatPhong(txtSoPhong, txtGia, cmbLoaiPhong, ref phong, 
                dtgThongTinPhong, e.RowIndex);
            MessageBox.Show(phong.LoaiPhong);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClickCancel.CancelDatPhong(txtTenKH, txtCMT, txtDiaChi, txtSDT, cmbGioiTinh, dtpNgaySinh);
        }

        private void cmbLoaiPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cmbLoaiPhong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadUtil.timKiemDuLieuPhong(dtgThongTinPhong, "Phong", cmbLoaiPhong.Text);
        }

        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
