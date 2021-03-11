using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyKhachSan.Connection;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.Model
{
    class ExcuteAdd
    {
        public static void ThemNhanVien(TextBox ma, TextBox ten, TextBox diaChi, 
            TextBox sdt, ComboBox chucVu, DateTimePicker ngaySinh, ComboBox gt, TextBox tk, TextBox mk)
        {
            if (ma.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (ten.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (diaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập địa chỉ nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sdt.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập số điện thoại của nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tk.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập tài khoản đăng nhập của nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (mk.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập mật khẩu đăng nhập nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String query = "Select manv from NhanVien";
                if (KiemTra.kiemTraTonTai(query, ma.Text.Trim()))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (KiemTra.kiemTraTonTai("select taikhoan from NhanVien", tk.Text.Trim()))
                    {
                        MessageBox.Show("Tài khoản nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Boolean gioiTinh;
                        if (gt.Text == "Nam")
                        {
                            gioiTinh = true;
                        }
                        else
                        {
                            gioiTinh = false;
                        }
                        string queryAdd = "insert into NhanVien values ('" + ma.Text.Trim() + "',N'" + ten.Text.Trim() + "',N'" + diaChi.Text.Trim() + "','" + sdt.Text.Trim() + "',N'" + chucVu.Text.Trim() + "','" + ngaySinh.Value.ToString() + "', '" + gioiTinh + "','" + tk.Text.Trim() + "','" + mk.Text.Trim() + "')";
                        if (DBConnection.ExcuteQuery(queryAdd))
                        {
                            LoadUtil.cleanQuanLyNhanVienScreen(ma, ten, sdt, diaChi, tk, mk);
                        }
                    }
                    
                }
            }
            
        }

        public static void DatPhong(ComboBox loaiPhong, DateTimePicker ngayDat, TextBox soPhong, TextBox gia,
            TextBox tenKH, TextBox soCMT, TextBox diaChi, TextBox sdt, ComboBox gT, DateTimePicker ngaySinh, Entity.Phong phong)
        {
            if (phong == null)
            {
                MessageBox.Show("Bạn phải lựa chọn phòng ở bảng danh sách phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (phong.TinhTrang == true)
                {
                    MessageBox.Show("Phòng đã được đặt rôi!\n Hãy chọn phòng khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (soPhong.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Hãy nhập số phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (gia.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Hãy nhập giá phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                    //    try
                       // {
                            double giaPhong = double.Parse(gia.Text.Trim());
                            if (giaPhong <= 0)
                            {
                                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (tenKH.Text.Trim().Equals(""))
                                {
                                    MessageBox.Show("Hãy nhập tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (soCMT.Text.Trim().Equals(""))
                                {
                                    MessageBox.Show("Hãy nhập số chứng minh thư khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (diaChi.Text.Trim().Equals(""))
                                {
                                    MessageBox.Show("Hãy nhập địa chỉ khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (sdt.Text.Trim().Equals(""))
                                {
                                    MessageBox.Show("Hãy nhập số điện thoại khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {

                                    String queryUpdatePhong = "update Phong set tinhtrang = '" + true + "' where sophong = '" + soPhong.Text.Trim() + "'";
                                    MessageBox.Show(soPhong.Text.Trim());
                                    Boolean gioiTinh;
                                    if (gT.Text == "Nam")
                                    {
                                        gioiTinh = true;
                                    }
                                    else
                                    {
                                        gioiTinh = false;
                                    }
                                    String query = "select cmt from khachHang";
                                    String queryAddKhachHang = "";
                                    if (Model.KiemTra.kiemTraTonTai(query, soCMT.Text.ToString().Trim()))
                                    {
                                        queryAddKhachHang = "update khachHang set tenkh = N'"+tenKH.Text.Trim()+"' ,sdt = '"+sdt.Text.Trim()+"' ,diaChi = N'"+diaChi.Text.Trim()+"' ,gioiTinh = '"+gioiTinh+"' ,ngaySinh = '"+ngaySinh.Value.ToString("yyyy-MM-dd")+"' where cmt = '"+soCMT.Text.Trim()+"'";
                                       
                                    }
                                    else
                                    {
                                        
                                        queryAddKhachHang = "insert into KhachHang values ('" + soCMT.Text.Trim() + "',N'" + tenKH.Text.Trim() + "','" + sdt.Text.Trim() + "','" + diaChi.Text.Trim() + "','" + gioiTinh + "','" + ngaySinh.Value.ToString("yyyy-MM-dd") + "')";
                                    }

                                    String queryAddHoaDon = "insert into HoaDon values ('" + soCMT.Text.Trim() + "', '" + soPhong.Text.Trim() + "','" + ngayDat.Value.ToString("yyyy-MM-dd") + "','" + null + "','" + false + "')";
                                    DBConnection.ExcuteQuery(queryUpdatePhong);
                                    DBConnection.ExcuteQuery(queryAddKhachHang);
                                    DBConnection.ExcuteQuery(queryAddHoaDon);
                                    soPhong.Text = "";
                                    gia.Text = "";
                                    tenKH.Text = "";
                                    soCMT.Text = "";
                                    diaChi.Text = "";
                                    sdt.Text = "";
                                }
                            }
                        //}
                    /*   catch (Exception ex)
                        {
                            MessageBox.Show("Nhập sai định dạng giá phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }*/
                    }
                }

            }
        }
    }
}
