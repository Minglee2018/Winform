using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Connection;
using System.Windows.Forms;
using System.Drawing;
using QuanLyKhachSan.View;

namespace QuanLyKhachSan.Model
{
    class Util
    {



        public static Boolean kiemTraDangNhap(String tk, String mk, String cv, String tenBang)
        {
            String query = "select * from " + tenBang;
            SqlDataReader reader = DBConnection.getDataReader(query);
            
            while (reader.Read())
            {
               
                if (tk.Equals(reader.GetString(7).Trim()) 
                    && mk.Equals(reader.GetString(8).Trim()) 
                    && cv.Equals(reader.GetString(4).Trim()))
                {
                   
                    return true;
                }
            }

            return false;

        }

        public static void khoiTaoManHinh(Form parentForm, Form childForm,String nameChildForm,  
            Form f1,  Form f2,  Form f3, ref Boolean childFormKT, ref Boolean f1KT, ref Boolean f2KT,ref Boolean f3KT )
        {
            if (childFormKT == false)
            {
                
                if (nameChildForm == "KhachHangScreen")
                {
                    childForm = new View.KhachHangScreen();
                }else if (nameChildForm == "DatPhongScreen")
                {
                    childForm = new View.DatPhongScreen();
                }else if (nameChildForm == "DatDV")
                {
                    childForm = new View.DatDV();
                }else if (nameChildForm == "HoaDon")
                {
                    childForm = new View.HoaDon();
                }

                childForm.MdiParent = parentForm;
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.Location = new Point(0,0);
                childForm.Show();
                childFormKT = true;
                f1 = null;
                f1KT = false;
                f2 = null;
                f2KT = false;
                f3 = null;
                f3KT = false;

            }
            else
            {
                MessageBox.Show("Màn hình đang hiển thị");
            }
           
           

        }
        public static void createMDIChild(String name, Form parent, Form child)
        {
            if (!checkExistsForm(parent, name))
            {
                if (name == "QuanLyNhanVienScreen")
                {
                    child = new View.QuanLyNhanVienScreen();
                }else if (name == "KhachHangScreen")
                {
                    child = new View.KhachHangScreen();
                }else if (name == "DichVuScreen")
                {
                    child = new View.DichVuScreen();
                }else if (name == "DatPhongScreen")
                {
                    child = new View.DatPhongScreen();
                }else if (name == "Phong")
                {
                    child = new View.Phong();
                }
                
                child.MdiParent = parent;
                child.StartPosition = FormStartPosition.Manual;
                child.Location = new Point(0,0);
                child.Show();
            }
            else
            {
                activeChildForm(parent,name);
            }
        }

        private static Boolean checkExistsForm(Form form, String name)
        {
            foreach (Form item in form.MdiChildren)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private static void activeChildForm(Form form, String name)
        {
            foreach(Form item in form.MdiChildren)
            {
                if (item.Name == name)
                {
                    item.Activate();
                    break;
                }
            }
        }
    }
}
