using System;
using QuanLyKhachSan.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.View
{
    public partial class Phong : Form
    {
        public Phong()
        {
            InitializeComponent();
            cmbLoaiPhong.Text = "Vip";
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            XuLy.hienthiTTPhong(dgvPhong);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //this.Close();
            XuLy.huyThongTinHienThi(txtSoPhong, cmbLoaiPhong, txtGia);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy.themPhong(txtGia, txtSoPhong, cmbLoaiPhong);
            Phong_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtSoPhong.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không để trống số phòng","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XuLy.xoaPhong(txtSoPhong, txtGia, cmbLoaiPhong);
                Phong_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy.suaTTPhong(txtSoPhong, cmbLoaiPhong, txtGia);
            Phong_Load(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int viTri = e.RowIndex;
            XuLy.CellClickBangThongTinPhong(txtSoPhong, txtGia, cmbLoaiPhong, dgvPhong, viTri);
        }
    }
}
