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

namespace QuanLyKhachSan.View
{
    public partial class DatDV : Form
    {
        public DatDV()
        {
            InitializeComponent();
            cmbSoLuong.Items.Add("1");
            cmbSoLuong.Items.Add("2");
            cmbSoLuong.Items.Add("3");
            cmbSoLuong.Items.Add("4");
            cmbSoLuong.Items.Add("5");
            cmbSoLuong.Items.Add("6");
            cmbSoLuong.Items.Add("7");
            cmbSoLuong.Items.Add("8");
            cmbSoLuong.Items.Add("9");
            cmbSoLuong.Items.Add("10");
            cmbSoLuong.Items.Add("12");
            cmbSoLuong.Items.Add("13");
            cmbSoLuong.Items.Add("14");
            cmbSoLuong.Items.Add("15");
            cmbSoLuong.Text = "1";
        }

        private void DatDV_Load(object sender, EventArgs e)
        {
            // lúc mới khởi tạo combobox phòng không có dữ liệu thì sao m
           
            XuLy.hienthiPhongDatDV(cmbPhong);
            XuLy.HienThiDV(dgvTTDV);
        }

     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPhong_DropDownClosed(object sender, EventArgs e)
        {
            XuLy.hienthiDVDaDat(cmbPhong, dgvDatDV,txtThanhTien);
            
        }

        private void dgvTTDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static int index = 0;
        private void dgvTTDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;   
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy.themDV(dgvTTDV, cmbSoLuong, cmbPhong,index);
            XuLy.hienthiDVDaDat(cmbPhong, dgvDatDV,txtThanhTien);
        }
        public static int index2 = 0;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            XuLy.xoaDVDaDat(dgvDatDV, cmbPhong, index2);
            XuLy.hienthiDVDaDat(cmbPhong, dgvDatDV, txtThanhTien);
        }
    }
}
