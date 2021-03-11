using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Entity
{
    class Phong
    {
        private int soPhong;

        public int SoPhong
        {
            get { return soPhong; }
            set { soPhong = value; }
        }
        private String loaiPhong;

        public String LoaiPhong
        {
            get { return loaiPhong; }
            set { loaiPhong = value; }
        }
        private Boolean tinhTrang;

        public Boolean TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }

        private double donGia;

        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public Phong(int soPhong, String loaiPhong, Boolean tinhTrang, double donGia)
        {
            this.soPhong = soPhong;
            this.loaiPhong = loaiPhong;
            this.tinhTrang = tinhTrang;
            this.donGia = donGia;
        }
    }
}
