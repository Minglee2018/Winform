using System;
using System.Collections.Generic;
using System.Text;

namespace phanso
{
    class Data
    {
        private int a, b; 
        public Data (int a,int b)
        {
            this.a = a;
            this.b = b;
        }
        public int UCLN(int a,int b)
        {
            return (b == 0) ? a : UCLN(b, a % b); 
        }
        public int A
        {
            get { return this.a; }
            set { this.a = value; }
        }
        public int B
        {
            get { return this.b; }
            set { this.b = value; }
        }
    }
}
