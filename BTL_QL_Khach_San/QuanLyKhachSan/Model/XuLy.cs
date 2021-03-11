using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKhachSan.Connection;

namespace QuanLyKhachSan.Model
{
    class XuLy
    {

        /////////////////////////form Đặt dịch vụ
        public static void hienthiPhongDatDV(ComboBox cmbP)
        {
            try
            {
                cmbP.DataSource = DBConnection.getTable("select *from Phong where tinhTrang=1");
                cmbP.DisplayMember = "soPhong";
                cmbP.ValueMember = "soPhong";

            }
            catch
            {

                MessageBox.Show("Không hiển thị được thông tin phòng !");
            }

        }



        public static void HienThiDV(DataGridView dgvDV)
        {
            try
            {
                dgvDV.DataSource = DBConnection.getTable("select *from DichVu");

            }
            catch
            {

                MessageBox.Show("Không hiển thị được thông tin dịch vụ !");
            }
        }

        public static void hienthiDVDaDat(ComboBox cmbP, DataGridView dgvDVdadat, TextBox txtThanhTien)
        {
            try
            {
                String mahd = null;
                SqlDataReader a = DBConnection.getDataReader("SELECT maHD FROM HoaDon WHERE thanhToan = 0 AND soPhong='" + cmbP.SelectedValue.ToString() + "'");

                while (a.Read())
                {
                    mahd = a["maHD"].ToString();
                }
                String query = "SELECT DichVu.maDV,tenDV,donGia,soluong,(soluong*donGia) as N'ThanhTien' " +
                "FROM dbo.DichVu INNER JOIN dbo.DatDV ON DatDV.maDV = DichVu.maDV " +
                 "Where maHD='" + mahd + "'";
                dgvDVdadat.DataSource = DBConnection.getTable(query);
                double thanhtien = 0;
                for (int i = 0; i < dgvDVdadat.Rows.Count ; i++)
                {
                    thanhtien += Double.Parse(dgvDVdadat.Rows[i].Cells[4].Value.ToString());
                }

                txtThanhTien.Text = thanhtien.ToString();

            }
            catch
            {

                MessageBox.Show("Lỗi kết nối !");
            }

        }

        public static void themDV(DataGridView dgvDV, ComboBox cmbsoluong, ComboBox CmbsoP, int index)
        {
            try
            {
                String maDV = dgvDV.Rows[index].Cells[0].Value.ToString();
                // MessageBox.Show("" + CmbsoP.SelectedValue.ToString()+"madv="+maDV+"so luong = "+ cmbsoluong.SelectedItem.ToString());
                String sql = "EXEC dbo.ThemDV1 @maDV = '" + maDV + "', @soLuong = '" + cmbsoluong.SelectedItem.ToString() + "',@soPhong ='" + CmbsoP.SelectedValue.ToString() + "'";
                DBConnection.ExcuteQuery(sql);
            }
            catch
            {

                MessageBox.Show("Phải chọn phòng");
            }
        }
        public static void xoaDVDaDat(DataGridView dgvDVdadat, ComboBox CmbsoP, int index2)
        {
            try
            {
                String maDV = dgvDVdadat.Rows[index2].Cells[0].Value.ToString();
                String sql = "EXEC dbo.XoaDV1 @soPhong ='" + CmbsoP.SelectedValue.ToString() + "',@maDV = '" + maDV + "'";
                DBConnection.ExcuteQuery(sql);
            }
            catch
            {
                MessageBox.Show("Không còn dịch vụ để xóa");
            }
        }
        /////////////////////////Form Quan lý thông tin dich vụ
        ///
        public static void ThemTTDV(TextBox txtmadv, TextBox txttendv, TextBox txtgia, RichTextBox rtbMota)
        {
            try
            {
                double gia = double.Parse(txtgia.Text);
                String kiemTraDv = "select maDV from DichVu where maDV='" + txtmadv.Text + "'";
                if (KiemTra.kiemTraTonTai(kiemTraDv, txtmadv.Text) == true)
                {
                    MessageBox.Show("Đã trùng mã dịch vụ");
                } else
                {
                    String sql = "insert into DichVu values (N'" + txtmadv.Text + "',N'" + txttendv.Text + "',N'" + rtbMota.Text + "','" + gia + "')";
                    DBConnection.ExcuteQuery(sql);
                    MessageBox.Show("Thêm thành công !");
                }

            }
            catch (FormatException ex)
            {

                MessageBox.Show("Giá phải để kiểu số");
            }
        }
        public static void suaTTDV(TextBox txtmadv, TextBox txttendv, TextBox txtgia, RichTextBox rtbMota)
        {
            try
            {


                double gia = double.Parse(txtgia.Text);
                String kiemTraDv = "select maDV from DichVu where maDV='" + txtmadv.Text + "'";
                if (KiemTra.kiemTraTonTai(kiemTraDv, txtmadv.Text) == false)
                {
                    MessageBox.Show("Không tồn tại mã dịch vụ này");
                }
                else
                {
                    String sql = "update DichVu set tenDV=N'" + txttendv.Text + "',moTa=N'" + rtbMota.Text + "',donGia='" + gia + "' where maDV='" + txtmadv.Text + "'";
                    DBConnection.ExcuteQuery(sql);
                    MessageBox.Show("Sửa thành công !");
                }
            }
            catch (FormatException ex)
            {

                MessageBox.Show("Giá phải để kiểu số");
            }

        }
        public static void xoaTTDV(TextBox txtmadv)
        {
            try
            {
                String kiemTraDv = "select maDV from DichVu where maDV='" + txtmadv.Text + "'";
                if (KiemTra.kiemTraTonTai(kiemTraDv, txtmadv.Text) == false)
                {
                    MessageBox.Show("Không tồn tại mã dịch vụ này");
                }
                else
                {
                    String sql = "Delete DichVu where maDV='" + txtmadv.Text + "'";
                    DBConnection.ExcuteQuery(sql);
                    MessageBox.Show("Xóa thành công !");
                }
            }
            catch
            {

                MessageBox.Show("Dịch vụ này đã tồn tại trong hóa đơn!!");
            }
        }
        public static void TimKiemDV(DataGridView dgvDV, TextBox txtDVtimKiem)
        {
            try
            {
                if (txtDVtimKiem.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Mã dịch vụ/ tên dịch vụ không được bỏ trống");
                }
                else
                {
                    String sql = "select * from DichVu where TenDV like N'%" + txtDVtimKiem.Text + "%' or MaDV like '%" + txtDVtimKiem.Text + "%'";
                    dgvDV.DataSource = DBConnection.getTable(sql);
                }
            }
            catch
            {
                MessageBox.Show("Không tìm được DV !!");
            }
        }
        ///////////////////////////////Hóa đơn
        ///
        public static void HienThiPhongThanhToan(DataGridView dgvphongthanhtoan)
        {
            try
            {
                dgvphongthanhtoan.DataSource = DBConnection.getTable("select soPhong from Phong where tinhTrang=1");
            }
            catch
            {

                MessageBox.Show("Không hiển thị được thông tin phòng !");
            }
        }
        public static void hienthiHoaDon(DataGridView dgvphongthanhtoan, int index, DataGridView dgvDVdadat, TextBox txtmaHD
                                          , TextBox txtsoPhong, TextBox txtTenKH, DateTimePicker dtpNgaySinh, TextBox txtGT, TextBox txtDiachi, TextBox txtsoCMT,
                                          TextBox txtNgayvao, TextBox txtNgayra, TextBox txtGiaPhong, TextBox txtTongtien)
        {
            try
             {
            int sophong = int.Parse(dgvphongthanhtoan.Rows[index].Cells[0].Value.ToString());
            String mahd = null;
            SqlDataReader a = DBConnection.getDataReader("SELECT maHD FROM HoaDon WHERE thanhToan = 0 AND soPhong='" + sophong + "'");
            while (a.Read())
            {
                mahd = a["maHD"].ToString();
            }
            txtmaHD.Text = mahd;
            txtsoPhong.Text = sophong.ToString();
            String query = "SELECT DichVu.maDV,tenDV,donGia,soluong,(soluong*donGia) as N'ThanhTien' " +
                "FROM dbo.DichVu INNER JOIN dbo.DatDV ON DatDV.maDV = DichVu.maDV " +
                 "Where maHD='" + mahd + "'";
            dgvDVdadat.DataSource = DBConnection.getTable(query);
            String sql = "select  tenKH, gioiTinh,diaChi, ngaySinh,KhachHang.CMT,ngayVao,gia "
                     + " from HoaDon inner join KhachHang on HoaDon.CMT=KhachHang.CMT "
                     + "inner join Phong on HoaDon.soPhong=Phong.soPhong "
                     + "where HoaDon.maHD='" + mahd + "' and HoaDon.thanhToan='False'  ";
            SqlDataReader b = DBConnection.getDataReader(sql);
            while (b.Read())
            {
                txtTenKH.Text = b["tenKH"].ToString();
                if (b.GetBoolean(1) == true)
                {
                    txtGT.Text = "Nam";
                }
                else
                {
                    txtGT.Text = "Nữ";
                }
                txtDiachi.Text = b["diaChi"].ToString();
                dtpNgaySinh.Value = b.GetDateTime(3);
                txtNgayvao.Text = b.GetDateTime(5).ToString("yyyy-MM-dd");
                txtsoCMT.Text = b["CMT"].ToString();
                txtGiaPhong.Text = b["gia"].ToString();
            }
            String ngayra = DateTime.Now.ToString("yyyy-MM-dd");
            txtNgayra.Text = ngayra;
            DBConnection.ExcuteQuery("update HoaDon set ngayRa = '" + ngayra + "' where maHD = '" + mahd + "'");
            String soNgayO = "select DATEDIFF(DAYOFYEAR, ngayVao, ngayRa) as'ngay' from HoaDon where maHD = '" + mahd + "'";
            SqlDataReader songayo = DBConnection.getDataReader(soNgayO);
            int dem = 1;
            while (songayo.Read())
            {
                dem = dem + songayo.GetInt32(0);
            }
            Double gia = Double.Parse(txtGiaPhong.Text.Trim());

            /////Tính tiền dv
            Double tiendv = 0;
            String tongtiendv = "select sum(soluong* donGia)as 'thanhtien' from DichVu inner join DatDV on DichVu.maDV = DatDV.maDV where maHD = '" + mahd + "'";
            SqlDataReader tongtienDV = DBConnection.getDataReader(tongtiendv);
            while (tongtienDV.Read())
            {
                if (!tongtienDV[0].ToString().Equals(""))
                {
                    tiendv = Double.Parse(tongtienDV[0].ToString());
                }

            }
            txtTongtien.Text = ((gia * dem) + tiendv).ToString();
            }
            catch
           {

             MessageBox.Show("Lỗi hiển thị thông tin hóa đơn !");
        }
        } 

        public static void xuatHoaDon(TextBox txtMaHD, TextBox txtsoPhong)
        {
            try
            {
                String mahd = txtMaHD.Text;
                String sophong = txtsoPhong.Text;
                DBConnection.ExcuteQuery("update HoaDon set thanhToan='True' where maHD='" + mahd + "'");
                DBConnection.ExcuteQuery("update Phong set tinhTrang='false' where soPhong='" + sophong + "'");
                MessageBox.Show("Xuất hóa thành công");
            }
            catch 
            {

                MessageBox.Show("Lỗi không xuất được hóa đơn !!");
            }

            
        }

        ///khách Hàng

        public static void hienthiKhachHang(DataGridView dgv)
        {
            try
            {
                dgv.DataSource = DBConnection.getTable("select * from KhachHang");
            }
            catch
            {
                MessageBox.Show("Không hiển thị thông tin khách hàng");
            }
        }
        public static void themKhachHang(TextBox txtCMT, TextBox txtTenKH, TextBox txtSDT, 
            TextBox txtDiaChi, RadioButton GioiTinh, DateTimePicker dtpNgaySinh)
        {
            try
            {
                if (txtCMT.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Bạn chưa nhập số chứng minh thư!", "Lỗi", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                }else if (txtTenKH.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Bạn chưa nhập tên khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtDiaChi.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtSDT.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    int CMT = int.Parse(txtCMT.Text);
                    string SDT = txtSDT.Text.ToString().Trim();
                    string TenKH = txtTenKH.Text;
                    string NgaySinh = dtpNgaySinh.Text;
                    string DiaChi = txtDiaChi.Text;
                    Boolean gt;
                    if (GioiTinh.Checked == true)
                    {
                        gt = true;
                    }
                    else
                    {
                        gt = false;
                    }


                    string sql = "insert into KhachHang values ('" + CMT + "',N'" + TenKH + "','" + SDT + "','" + DiaChi + "','" + gt + "','" + NgaySinh + "')";
                    DBConnection.ExcuteQuery(sql);
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("trùng cmt!");
            }
        }
        public static void xoaKhachHang(TextBox txtCMT)
        {
            if (txtCMT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Hãy nhập vào số CMT/CCCD để thực hiện thao tác!","Lỗi"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int CMT = int.Parse(txtCMT.Text);
                    String query = "select cmt from KhachHang";

                   
                    if (Model.KiemTra.kiemTraTonTai(query, txtCMT.Text.ToString().Trim()))
                    {
                        string sql = "delete KhachHang where CMT='" + CMT + "'";
                        DBConnection.ExcuteQuery(sql);
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại khách hàng này!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                catch (FormatException)
                {
                    MessageBox.Show("CMT phải là số");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Số CMT/CCCD đang tồn tại ở trong hóa đơn!");
                }
            }
            
        }

        public static void capnhatKhachHang(TextBox txtCMT, TextBox txtTenKH, TextBox txtSDT,
            TextBox txtDiaChi, RadioButton GioiTinh, DateTimePicker dtpNgaySinh)
        {

            if (txtCMT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập số chứng minh thư!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtTenKH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSDT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int cmt = int.Parse(txtCMT.Text);
                    double SDT = double.Parse(txtSDT.Text);
                    string tenKH = txtTenKH.Text;
                    string DiaChi = txtDiaChi.Text;
                    string NgaySinh = dtpNgaySinh.Text;
                    Boolean gt;
                    if (GioiTinh.Checked == true)
                    {
                        gt = true;
                    }
                    else
                    {
                        gt = false;
                    }
                    String query = "select cmt from khachhang";
                    if (Model.KiemTra.kiemTraTonTai(query, txtCMT.Text.ToString().Trim()))
                    {
                        string sql = "update KhachHang set CMT='" + cmt + "' ,TenKH = N'" + tenKH + "' ,SDT='" + SDT + "',DiaChi = N'" + DiaChi + "',GioiTinh='" + gt + "',ngaySinh='" + NgaySinh + "' where CMT = '" + cmt + "'";
                        DBConnection.ExcuteQuery(sql);
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại khách hàng này!","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //string query = "update PHONG SET loaiPhong = N'" + loaiphong+"', tinhTrang = '"+0+"' , gia = '"+gia+"' where soPhong = '" + sophong + "'";
                    

                }
                catch (FormatException)
                {

                    MessageBox.Show("CMT và giá phải là số");
                }
            }
            
        }

        public static void timKiemKhachHang(TextBox txtTenKH, TextBox txtMaKH, DataGridView dtgThongTin)
        {
            if (txtTenKH.Text.Trim().Equals("") && txtMaKH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập tên hoặc số CMT/CCCD khách hàng để tìm kiếm!");
            }
            else
            {
                String query = "";
                if (txtTenKH.Text.Trim().Equals(""))
                {
                    query = "select * from KhachHang where cmt like '%"+txtMaKH.Text.Trim()+"%'";
                }else if (txtMaKH.Text.Trim().Equals(""))
                {
                    query = "select * from KhachHang where tenkh like N'%"+txtTenKH.Text.Trim()+"%'";
                }
                else
                {
                    query = "select * from KhachHang where tenkh like N'%" + txtTenKH.Text.Trim() + "%' and cmt like '%" + txtMaKH.Text.Trim() + "%'";
                }
                dtgThongTin.DataSource = DBConnection.getTable(query);
            }
        }

        public static void huyThongTinHienThi(TextBox txtCMT, TextBox txtTenKH, TextBox txtSDT,
            TextBox txtDiaChi, RadioButton rdNam)
        {
            txtCMT.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            rdNam.Checked = true;
        }
        public static void huyThongTinTimKiem(TextBox txtTen, TextBox txtMa)
        {
            txtTen.Text = "";
            txtMa.Text = "";
        }

        public static void CellClickBangKhachHang(TextBox txtCMT, TextBox txtTenKH, TextBox txtSDT,
            TextBox txtDiaChi, RadioButton GioiTinhNam, RadioButton gioiTinhNu, DateTimePicker dtpNgaySinh, DataGridView dtp , int viTri)
        {
            txtCMT.Text = dtp.Rows[viTri].Cells[0].Value.ToString().Trim();
            txtTenKH.Text = dtp.Rows[viTri].Cells[1].Value.ToString().Trim();
            txtSDT.Text = dtp.Rows[viTri].Cells[2].Value.ToString().Trim();
            txtDiaChi.Text = dtp.Rows[viTri].Cells[3].Value.ToString().Trim();
            if (dtp.Rows[viTri].Cells[4].Value.ToString().Equals("True"))
            {
                GioiTinhNam.Checked = true;
            }
            else
            {
                gioiTinhNu.Checked = true;
            }
            dtpNgaySinh.Text = dtp.Rows[viTri].Cells[5].Value.ToString().Trim(); 
        }

        //Phòng
        //////////////////////Phòng
        public static void hienthiTTPhong(DataGridView dgv)
        {
            try
            {
                //dgv.DataSource = DBConnection.getTable("select * from Phong");
                dgv.DataSource = DBConnection.getTable("select soPhong , loaiPhong , gia from Phong");
            }
            catch
            {
                MessageBox.Show("Không hiển thị thông tin phòng");
            }
        }
        public static void themPhong(TextBox txtGia, TextBox txtSoPhong, ComboBox cmbLoaiPhong)
        {
            if (txtSoPhong.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Hãy nhập vào số phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtGia.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Hãy nhập vào giá phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int sophong = int.Parse(txtSoPhong.Text);
                    double gia = double.Parse(txtGia.Text);
                    string loaiphong = cmbLoaiPhong.Text;
                    string sql = "insert into Phong values ('" + sophong + "',N'" + loaiphong + "','false','" + gia + "')";
                    DBConnection.ExcuteQuery(sql);
                    txtGia.Text = "";
                    txtSoPhong.Text = "";
                    cmbLoaiPhong.Text = "Vip";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Số phòng và giá phải là số");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Số phòng đã tồn tại!");
                }
            }

            
        }
        public static void xoaPhong(TextBox txtSoPhong, TextBox txtGia, ComboBox cmb)
        {
            String query = "select sophong from Phong";

            if (Model.KiemTra.kiemTraTonTai(query, txtSoPhong.Text.ToString().Trim()))
            {
                try
                {
                    int sophong = int.Parse(txtSoPhong.Text);
                    string sql = "delete Phong where SoPhong='" + sophong + "'";
                    DBConnection.ExcuteQuery(sql);
                    huyThongTinHienThi(txtSoPhong, cmb, txtGia);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Số phòng và giá phải là số");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi truy xuất cơ sở dữ liệu!");
                }
            }
            else
            {
                MessageBox.Show("Số phòng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public static void suaTTPhong(TextBox txtSoPhong, ComboBox cmbLoaiPhong, TextBox txtGia)
        {
            if (txtSoPhong.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Hãy nhập vào số phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtGia.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Hãy nhập vào giá phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    String query = "select soPhong from phong";
                    if (Model.KiemTra.kiemTraTonTai(query, txtSoPhong.Text.Trim().ToString()))
                    {
                        int sophong = int.Parse(txtSoPhong.Text);
                        double gia = double.Parse(txtGia.Text);
                        string loaiphong = cmbLoaiPhong.Text;
                        //string query = "update PHONG SET loaiPhong = N'" + loaiphong+"', tinhTrang = '"+0+"' , gia = '"+gia+"' where soPhong = '" + sophong + "'";
                        string sql = "update Phong set loaiphong=N'" + loaiphong + "' ,tinhtrang = '" + 0 + "' ,gia = '" + gia + "' where soPhong = '" + sophong + "'";
                        DBConnection.ExcuteQuery(sql);
                       
                    }
                    else
                    {
                        MessageBox.Show("Số phòng không tồn tại!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Số phòng và giá phải là số","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }
        
        public static void huyThongTinHienThi(TextBox txtSoPhong, ComboBox cmbLoaiPhong, TextBox txtGia)
        {
            txtGia.Text = "";
            txtSoPhong.Text = "";
            cmbLoaiPhong.Text = "Vip";
        }

        public static void CellClickBangThongTinPhong(TextBox soPhong , TextBox giaPhong, ComboBox loaiPhong, DataGridView dt, int viTri)
        {
            soPhong.Text = dt.Rows[viTri].Cells[0].Value.ToString().Trim();
            loaiPhong.Text = dt.Rows[viTri].Cells[1].Value.ToString().Trim();
            giaPhong.Text = dt.Rows[viTri].Cells[2].Value.ToString().Trim();
        }
        
    }
}
