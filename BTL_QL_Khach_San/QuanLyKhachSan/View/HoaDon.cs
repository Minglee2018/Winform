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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            XuLy.HienThiPhongThanhToan(dgvPhongthanhtoan);
        }

        private void dgvPhongthanhtoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            XuLy.hienthiHoaDon(dgvPhongthanhtoan, index, dgvDVdadat, txtmaHD, txtSoPhong, txtTenKH, dtpNgaySinh,
                txtGioiTinh, txtDiaChi, txtSoCMT, txtNgayVao
                , txtNgayRa, txtGiaPhong, txtTongtien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtSoPhong.Text.Trim().Equals(""))
            {
                MessageBox.Show("Số phòng bị trống");
            }else if(txtmaHD.Text.Trim().Equals(""))
            {
                MessageBox.Show("Số hóa đơn bị trống");
            }
            else
            {
                XuLy.xuatHoaDon(txtmaHD, txtSoPhong);
                txtSoPhong.Text = "";
                txtmaHD.Text = "";
                HoaDon_Load(sender, e);

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Hóa Đơn", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(350, 25));
            e.Graphics.DrawString("Hóa đơn số: " + txtmaHD.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 55));
            e.Graphics.DrawString("Phòng số: " + txtSoPhong.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 85));
            e.Graphics.DrawString("Tên khách hàng: " + txtTenKH.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 115));
            e.Graphics.DrawString("Ngày sinh: " + dtpNgaySinh.Value.ToShortDateString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 145));
            e.Graphics.DrawString("Giói tính: " + txtGioiTinh.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 175));
            e.Graphics.DrawString("Địa chỉ: " + txtDiaChi.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 205));
            e.Graphics.DrawString("Số CMT : " + txtSoCMT.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 235));
            e.Graphics.DrawString("DỊCH VỤ ĐÃ ĐẶT : ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 275));
            int n = dgvDVdadat.RowCount;
            int y = 305;
            for (int i = 0; i < n ; i++)
            {
                e.Graphics.DrawString(dgvDVdadat.Rows[i].Cells[1].Value.ToString() + " Số lượng: "
                    + dgvDVdadat.Rows[i].Cells[3].Value.ToString() + " Đơn giá : "
                    + dgvDVdadat.Rows[i].Cells[2].Value.ToString() + " Thành tiền : "
                    + dgvDVdadat.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, y));
                y = y + 30;
            }
            e.Graphics.DrawString("Ngày vào : " + txtNgayVao.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, y + 30));
            e.Graphics.DrawString("Ngày ra: " + txtNgayRa.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, y + 60));
            e.Graphics.DrawString("Tổng tiền thanh toán : " + txtTongtien.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, y + 120));
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
