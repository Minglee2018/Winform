using System;

namespace PTB2
{
    class Program
    {
        static void Main(string[] args)
        {
            Single a, b, c;
            try
            {
                Console.Write("a = ");
                a = Convert.ToSingle(Console.ReadLine());
                Console.Write("b = ");
                b = Convert.ToSingle(Console.ReadLine());
                Console.Write("c = ");
                c = Convert.ToSingle(Console.ReadLine());

                if (a == 0)
                    if (b == 0)
                        if (c == 0)
                            Console.WriteLine("Phuong trinh vo so nghiem");
                        else
                            Console.WriteLine("Phuong trinh vo nghiem");
                    else
                        Console.WriteLine("PT suy bien, nghiem x = {0}", -c/b);
                else
                {
                    Single delta = b * b - 4 * a * c;
                    if (delta < 0)
                        Console.WriteLine("PT vo nghiem");
                    else if (delta == 0)
                        Console.WriteLine("PT co nghiem kep x = {0}", -b/(2*a));
                    else
                    {
                        Console.WriteLine("PT co 2 nghiem:");
                        Console.WriteLine("x1 = {0}",(-b-Math.Sqrt(delta))/2/a);
                        Console.WriteLine("x2 = {0}", (-b+Math.Sqrt(delta))/2/a);
                    }
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Input string was not in a correct format.");
            }

            Console.ReadLine();
        }
    }
}
