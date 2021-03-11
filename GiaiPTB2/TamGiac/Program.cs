using System;

namespace TamGiac
{
    class Program
    {
        static void Main(string[] args)
        {
            Double a, b, c;
            try
            {

                Console.Write("a = ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("b = ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("c = ");
                c = Convert.ToDouble(Console.ReadLine());

                if ((a <= 0) || (b <= 0) || (c <= 0) || (a + b <= c) || (a + c <= b) || (b + c <= a))
                    throw new Exception();

                Console.WriteLine("Chu vi tam giac: {0}", a + b + c);          
            }
            catch (FormatException)
            {
                Console.WriteLine("Sai kieu du lieu.");
            }
            catch (Exception)
            {
                Console.WriteLine("Khong phai 3 canh tam giac");
            }
            Console.ReadLine();
        }
    }
}
