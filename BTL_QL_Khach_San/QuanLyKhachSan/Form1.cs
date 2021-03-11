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

namespace QuanLyKhachSan
{
    public partial class Form1 : Form
    {
        private  View.KhachHangScreen khachHangScreen;
        private  View.DatPhongScreen datPhong;
        private  View.DatDV dichVu;
        private  View.HoaDon hoaDon;
        Form form;
        Boolean khscr = false, dpcsr = false, ddvscr = false, hdscr = false;

        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            //datPhong = new View.DatPhongScreen();
           
        }
        public Form1(Form form)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.form = form;
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {

            Model.Util.khoiTaoManHinh(this,khachHangScreen, "KhachHangScreen",
                datPhong, dichVu, hoaDon,ref khscr, ref dpcsr, ref ddvscr, ref hdscr);
            /*if (khachHangScreen == null)
            {
                khachHangScreen = new View.KhachHangScreen();
                khachHangScreen.MdiParent = this;
                khachHangScreen.ControlBox = false;
                khachHangScreen.StartPosition = FormStartPosition.Manual;
                khachHangScreen.Location = new Point(0, 0);
                khachHangScreen.Show();
            }
            if (datPhong != null)
            {
                datPhong = null;
            }
            if (dichVu != null)
            {
                dichVu = null;
            }
            if (hoaDon != null)
            {
                hoaDon = null;
            }*/
          
            
           

            
        }

        private void menuHoaDon_Click(object sender, EventArgs e)
        {
            
            Model.Util.khoiTaoManHinh(this, hoaDon, "HoaDon",  dichVu,  khachHangScreen, datPhong,
                ref hdscr, ref ddvscr, ref khscr, ref dpcsr);
            /*if (hoaDon == null)
            {
                hoaDon = new View.HoaDon();
                hoaDon.MdiParent = this;
                hoaDon.StartPosition = FormStartPosition.Manual;
                hoaDon.Location = new Point(0, 0);
                hoaDon.Show();
            }
            if (khachHangScreen != null)
            {
                khachHangScreen = null;
            }
            if (dichVu != null)
            {
                dichVu = null;
            }
            if (datPhong != null)
            {
                datPhong = null;
            }*/
            
            
        }

        private void menuPhong_Click(object sender, EventArgs e)
        {
            Model.Util.khoiTaoManHinh(this, datPhong, "DatPhongScreen", dichVu, hoaDon, khachHangScreen,
                ref dpcsr, ref ddvscr, ref hdscr, ref khscr );
            /*if (datPhong == null)
            {
                datPhong = new View.DatPhongScreen();
                datPhong.MdiParent = this;
                datPhong.ControlBox = false;
                datPhong.StartPosition = FormStartPosition.Manual;
                datPhong.Location = new Point(0, 0);
                datPhong.Show();
            }
            if (khachHangScreen != null)
            {
                khachHangScreen = null;
            }
            if (dichVu != null)
            {
                dichVu = null;
            }
            if (hoaDon != null)
            {
                hoaDon = null;
            }*/


            

        }

        private void menuDichVu_Click(object sender, EventArgs e)
        {

            Model.Util.khoiTaoManHinh(this, dichVu, "DatDV", hoaDon, khachHangScreen, datPhong,
                ref ddvscr, ref hdscr, ref khscr, ref dpcsr);
            
            /*if (dichVu == null)
            {
                dichVu = new View.DatDV();
                dichVu.MdiParent = this;
                dichVu.StartPosition = FormStartPosition.Manual;
                dichVu.Location = new Point(0, 0);
                dichVu.Show();
            }
            if (khachHangScreen != null)
            {
                khachHangScreen = null;
            }
            if (datPhong != null)
            {
                datPhong = null;
            }
            if (hoaDon != null)
            {
                hoaDon = null;
            }*/


        }
        private Boolean checkExistForm(String ten)
        {
            Boolean check = false;
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == ten) {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private void activeChildForm(String name)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == name)
                {
                    item.Activate();
                    break;
                }
               
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Model.Util.khoiTaoManHinh(this, datPhong, "DatPhongScreen", dichVu, hoaDon, khachHangScreen,
                ref dpcsr, ref ddvscr, ref hdscr, ref khscr);
            //Util.createMDIChild("DatPhongScreen", this, datPhong);
        }

        private void menuDangXua_Click(object sender, EventArgs e)
        {
            this.form.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Close();
        }
    }
}
