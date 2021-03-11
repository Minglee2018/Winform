using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Entity
{
    class NhanVien
    {
        //String ma, ten, diaChi, sdt, chucVu, ngaySinh, gt, tk, mk;
        private String ma;
        public NhanVien()
        {

        }
        public NhanVien(String ma, String ten, String diaChi,
            String sdt, String chucVu, String ngaySinh, String gt, String tk, String mk)
        {
            this.ma = ma;
            this.ten = ten;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.chucVu = chucVu;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gt;
            this.taiKhoan = tk;
            this.matKhau = mk;
        }


        public String Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        private String ten;

        public String Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private String diaChi;

        public String DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private String sdt;

        public String SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private String chucVu;

        public String ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }

        private String ngaySinh;

        public String NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        private String gioiTinh;

        public String GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        private String taiKhoan;

        public String TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }
        private String matKhau;

        public String MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

    }
}
