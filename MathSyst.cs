using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace я_и_толя
{
    class MathSyst
    {
        //расчёт SQRT
        static public double SQRTkv(double number)
        {
            // number - число под корнем         
            double t;
            double result = number / 2;
            do
            {
                t = result;
                result = (t + (number / t)) / 2;
            } while ((t - result) != 0);
            return result;
        }
        // расчёт факториала
        static public double Fack(double x)
        {
            double sum = 1;
            for (int i = 1; i <= x; i++)
                sum *= i;
            return sum;
        }
        //Модуль
        static public double Abs(double num)
        {
            if (num >= 0)
                return num;
            return -num;
        }
        //степень
        static public double Power(double x, double n)
        {
            if (n == 0)
                return 1;
            if (n % 2 == 0)
            {
                var p = Power(x, n / 2);
                return p * p;
            }
            else
                return x * Power(x, n - 1);
        }
        //Очистка
        static public string Clear(string value)
        {
            int lenght = value.Length - 1;
            string text = value;
            value = "";
            for (int i = 0; i < lenght; i++)
                value += text[i];
            return value;
        }
        //COS
        public static double Cos(double x, int n = 0, double precision = 1e-5)
        {
            var t = Power(-1, n) * Power(x, 2 * n) / MathSyst.Fack((uint)(2 * n));
            if (MathSyst.Abs(t) < precision)
                return t;
            return t + Cos(x, n + 1, precision);
        }
       
    }
}
