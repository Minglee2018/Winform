using System;

namespace TongChan
{
    class Tong
    {
        public static UInt32 soDoiTuong = 0;
        private UInt32 n;
        public UInt32 N
        {
            get { return n; }
            set { n = value; }
        }
        public Tong(UInt32 n)
        {
            soDoiTuong++;
            this.n = n;
        }
        public void Nhap()
        {
            Console.Write("n = ");
            n = Convert.ToUInt32(Console.ReadLine());
        }
        public void Xuat()
        {
            UInt32 tong = 0;
            for(UInt32 i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                    tong += i;
            }
            Console.WriteLine("Tong = " + tong);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            UInt32 n = Convert.ToUInt32(Console.ReadLine());
            Tong tong = new Tong(n);
            Tong tong2 = new Tong(n+2);
            Tong tong3 = new Tong(n+4);
            Tong tong4 = new Tong(n+6);
            //tong.Nhap();
            tong4.Xuat();

            Console.WriteLine("So doi tuong da duoc tao ra: " + Tong.soDoiTuong);
            Console.ReadLine();
        }
    }
}
