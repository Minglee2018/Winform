using QuanLyKhachSan.Model;
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

namespace QuanLyKhachSan.View
{
    public partial class DichVuScreen : Form
    {
        public DichVuScreen()
        {
            InitializeComponent();
        }

        private void DichVuScreen_Load(object sender, EventArgs e)
        {
            XuLy.HienThiDV(dgvDV);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaDV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã dịch vụ không để trống");
            }else if(txtTenDV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên dịch vụ không để trống");
            }
            else if (rtbMoTa.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả dịch vụ không để trống");
            }
            else if(txtDonGia.Text.Trim().Equals(""))
            {
                MessageBox.Show("Giá dịch vụ không để trống");
            }
            else
            {
                XuLy.ThemTTDV(txtMaDV, txtTenDV, txtDonGia, rtbMoTa);
                DichVuScreen_Load(sender, e);
            }
        }

        private void dgvDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            
            txtMaDV.Text = dgvDV.Rows[i].Cells[0].Value.ToString();
            txtDonGia.Text = dgvDV.Rows[i].Cells[3].Value.ToString();
            txtTenDV.Text= dgvDV.Rows[i].Cells[1].Value.ToString();
            rtbMoTa.Text = dgvDV.Rows[i].Cells[2].Value.ToString();

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã dịch vụ không để trống");
            }
            else if (txtTenDV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên dịch vụ không để trống");
            }
            else if (rtbMoTa.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả dịch vụ không để trống");
            }
            else if (txtDonGia.Text.Trim().Equals(""))
            {
                MessageBox.Show("Giá dịch vụ không để trống");
            }
            else
            {
                XuLy.suaTTDV(txtMaDV, txtTenDV, txtDonGia, rtbMoTa);
                DichVuScreen_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã dịch vụ không để trống");
            }
            else
            {
                XuLy.xoaTTDV(txtMaDV);
                DichVuScreen_Load(sender, e);
            }
        }

        private void btnTimKiemDV_Click(object sender, EventArgs e)
        {
            XuLy.TimKiemDV(dgvDV,txtMaDVTim);
        }

        private void dgvDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rtbMoTa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
