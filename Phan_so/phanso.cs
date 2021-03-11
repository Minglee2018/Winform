using System;
using System.Collections.Generic;
using System.Text;

namespace phanso
{
    class phanso :Data
    {
        private int c, d; 
        public phanso (int a,int b,int c,int d):base (a,b)
        {
            this.c = c;
            this.d = d;
        }
        public int C
        {
            get { return c; }
            set { c = value;  }
        }
        public int D
        {
            get { return d; }
            set { d = value; }
        }
        public void rutgon()
        {
            int x = UCLN(A, B);
            int y = UCLN(C, D);
            A /= x;
            B /= x;
            C /= y;
            D /= y; 

        }
        public string rutgon1(int a ,int b)
        {
            if (a % b == 0)
                return (a / b).ToString();
            else
            {
                int x = UCLN(a, b);
                int tu = a/x;
                int mau = b /x; 
                return tu.ToString() + "/" + mau.ToString();
            }
        }
        public string tong()
        {
            rutgon();
            int tu = A * c;
            int mau = B * d;
            return rutgon1(tu, mau); 
        }
        public string chia()
        {
            rutgon();
            int tu = A * d;
            int mau = B * c;
            return rutgon1(tu, mau); 
        }

    }
}
