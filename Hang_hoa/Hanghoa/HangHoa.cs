using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace colen
{
    class HangHoa
    {
        protected string maHang, tenHang, nhaSanXuat;

        public HangHoa()
        { }
        public HangHoa(string maHang,string tenHang,string nhaSanXuat)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.nhaSanXuat = nhaSanXuat;
        }

        public string MaHang
        {
            get { return this.maHang; }
            set { this.maHang = value; }
        }

        public string TenHang
        {
            get { return this.tenHang; }
            set { this.tenHang = value; }
        }

        public string NhaSanXuat
        {
            get { return this.nhaSanXuat; }
            set { this.nhaSanXuat = value; }
        }

        public virtual List<string> xuat()
        {
            List<string> myList = new List<string>();
            myList.Add(this.maHang);
            myList.Add(this.tenHang);
            myList.Add(this.nhaSanXuat);
            return myList;
        }

    }
}
