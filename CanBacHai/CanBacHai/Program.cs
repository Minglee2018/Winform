using System;
using System.Collections; // for ArrayList
using System.Collections.Generic; // for List<>

namespace CanBacHai
{
    class NegativeException : Exception
    {
        public NegativeException(String msg) : base(msg)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Double a, eps;
            Double x, xn = 1;
            try
            {
                Console.Write("a = ");
                a = Convert.ToDouble(Console.ReadLine());
                if (a < 0) throw new Exception("Ban da nhap vao so am.");
                Console.Write("eps = ");
                eps = Convert.ToDouble(Console.ReadLine());
                do
                {
                    x = xn;
                    xn = (a / x + x) / 2;
                } while (Math.Abs(xn - x) >= eps);
                Console.WriteLine("Sqrt(a) = {0:F5}", x);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("So a nhap vao khong dung dinh dang.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Khong the khai can cua mot so am.");
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}
