using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace я_и_толя
{
    class MathSyst
    {
        /*static double Factorial(uint num)
        {
            if (num <= 1)
                return 1d;
            return num * Factorial(num - 1);
        }
        static double Power(double num, int pow)
        {
            if (pow == 0)
                return 1;
            return num * Power(num, pow - 1);
        }
        static double Abs(double num)
        {
            if (num >= 0)
                return num;
            return -num;
        }
        public static double Cos(double x, int n = 0, double precision = 1e-5)
        {
            var t = Power(-1, n) * Power(x, 2 * n) / Factorial((uint)(2 * n));
            if (Abs(t) < precision)
                return t;
            return t + Cos(x, n + 1, precision);
        }
        public static void Main()
        {
            Console.Write("x = ");
            var x = double.Parse(Console.ReadLine());
            var grad = x * Math.PI / 180;
            var result = Cos(grad);
            Console.WriteLine("Cos(x) = {0:f4}", result);
            Console.WriteLine("Math.Cos(x) = {0:f4}", Math.Cos(grad));
            Console.ReadKey(true);
        }*/
    }
}
