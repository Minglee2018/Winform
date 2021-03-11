using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string getValue(Panel pnl)
        {
            RadioButton check = null;
            foreach(RadioButton hihi in pnl.Controls)
            {
                if(hihi.Checked==true)
                {
                    check = hihi;
                    break;
                }
            }
            return check.Text;
        }

        int Row;
        private void button1_Click(object sender, EventArgs e)
        {
            string maHang = txtmaHang.Text;
            string tenHang = txttenHang.Text;
            string nhaSanXuat = cmbnhaSanXuat.Text;
            string hanSuDung = cmbhanSuDung.Text;
            string nhomThuoc = getValue(pnlnhomThuoc);

            DuocPham product = new DuocPham(maHang,tenHang,nhaSanXuat,hanSuDung,nhomThuoc);

            Row = listView1.Items.Count;
            listView1.Items.Add(product.MaHang);
            listView1.Items[Row].SubItems.Add(product.TenHang);
            listView1.Items[Row].SubItems.Add(product.NhaSanXuat);
            listView1.Items[Row].SubItems.Add(product.NhomThuoc);
            listView1.Items[Row].SubItems.Add(product.HanSuDung);
            listView1.Items[Row].SubItems.Add(product.HanSuDung);
            

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
