using System;

namespace SoPhuc
{
    class SoPhuc
    {
        Double real;
        Double image;
        public SoPhuc()
        {
            real = 0;
            image = 0;
        }
        public SoPhuc(Double r, Double i)
        {
            real = r;
            image = i;
        }
        public void Print()
        {
            if (image >= 0)
                Console.Write("({0} + {1}i)", real, image);
            else
                Console.Write("({0} - {1}i)", real, -image);
        }
        public SoPhuc Add(SoPhuc sp)
        {
            SoPhuc result = new SoPhuc();
            result.real = real + sp.real;
            result.image = image + sp.image;
            return result;
        }
        public SoPhuc Sub(SoPhuc sp)
        {
            SoPhuc result = new SoPhuc();
            result.real = real - sp.real;
            result.image = image - sp.image;
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so phuc thu nhat: ");
            Console.Write("Phan thuc = ");
            Double r1 = Double.Parse(Console.ReadLine());
            Console.Write("Phan ao = ");
            Double i1 = Double.Parse(Console.ReadLine());

            SoPhuc sp1 = new SoPhuc(r1, i1);

            Console.WriteLine("Nhap vao so phuc thu hai: ");
            Console.Write("Phan thuc = ");
            Double r2 = Double.Parse(Console.ReadLine());
            Console.Write("Phan ao = ");
            Double i2 = Double.Parse(Console.ReadLine());

            SoPhuc sp2 = new SoPhuc(r2, i2);

            Console.WriteLine("Tong 2 so phuc da nhap la: ");
            sp1.Print();
            Console.Write(" + ");
            sp2.Print();
            Console.Write(" = ");
            sp1.Add(sp2).Print();

            Console.WriteLine("\nHieu 2 so phuc da nhap la: ");
            sp1.Print();
            Console.Write(" - ");
            sp2.Print();
            Console.Write(" = ");
            sp1.Sub(sp2).Print();

            Console.ReadLine();
        }
    }
}
