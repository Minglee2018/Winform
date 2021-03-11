using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colen
{
    class DuocPham : HangHoa
    {
        private string hanSuDung, nhomThuoc;
        public DuocPham(string maHang, string tenHang, string nhaSanXuat,string hanSuDung,string nhomThuoc):base(maHang,tenHang,nhaSanXuat)
        {
            this.hanSuDung = hanSuDung;
            this.nhomThuoc = nhomThuoc;
        }

        public string HanSuDung
        {
            get { return this.hanSuDung; }
            set { this.hanSuDung = value; }
        }

        public string NhomThuoc
        {
            get { return this.nhomThuoc; }
            set { this.nhomThuoc = value; }
        }

        public override List<string> xuat()
        {
            List<string> myList = new List<string>();
            myList.Add(this.maHang);
            myList.Add(this.tenHang);
            myList.Add(this.nhaSanXuat);
            myList.Add(this.nhomThuoc);
            myList.Add(this.hanSuDung);
            return myList;
        }
    }
}
