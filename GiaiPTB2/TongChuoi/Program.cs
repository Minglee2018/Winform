using System;

namespace TongChuoi
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt32 n, tong = 0;
            try
            {
                Console.Write("n = ");
                n = Convert.ToUInt32(Console.ReadLine());

                for (UInt32 i = 1; i <= n; i++)
                {
                    tong += i;
                }

                Console.WriteLine("Tong chuoi = {0}", tong);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception)
            {
                Console.WriteLine("Runtime error.");
            }
            Console.ReadLine();
        }
    }
}
