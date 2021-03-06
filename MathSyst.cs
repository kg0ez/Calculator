using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                if (Convert.ToInt32(n) == Convert.ToDouble(n))
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
                else return Math.Pow(x, n);


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
        //SIN
        public static double Sin(double x, int n = 1, double precision = 1e-5)
        {
            var t = MathSyst.Power(-1, n - 1) * MathSyst.Power(x, 2 * n - 1) / MathSyst.Fack((uint)(2 * n - 1));
            if (MathSyst.Abs(t) < precision)
                return t;
            return t + Sin(x, n + 1, precision);
        }
        //MINUSorPLUS
        static public double MorP(double znachenie)
        {
            znachenie = -1 * (znachenie);
            return znachenie;
        }
        public static int i;
        public static double Func(double x)
        {
            switch (i)
            {
                case 1: return 1 / Power(x, 2);
                case 2: return Cos(x);
                case 3: return Sin(x);
                case 4: return 1 / Power(Cos(x), 2);
                case 5: return 1 / Power(Sin(x), 2);
                case 6: return 1 / x;
                case 7: return Power(Math.E, x);
                case 8: return 1 / x * Math.Log(x);
                default: return 1 / Power(x, 2);
            }
        }
        //Корень из N
        public static double SqrtN(double n, double A, double eps = 0.0001)
        {
            var x0 = A / n;
            var x1 = (1 / n) * ((n - 1) * x0 + A / Power(x0, (int)n - 1));
            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + A / Power(x0, (int)n - 1));
            }
            var x2 = x1 % 1;
            var x3 = x1 - x2;
            double x4 = 1;
            for (int i = 0; i < n; i++)
                x4 *= (double)x3;
            if (x4 == A)
                return x3;
            else
                return x1;
        }
        public static double Cos_Sin(double x, double s)
        {
            if (s == 0)
            {
                if(x==30)
                    x=0.5;
                if (x == 90)
                    x = 1;
                if (x == 180)
                    x = 0;
                if (x == 270)
                    x = -1;
            }
            if (s == 1)
            {
                if (x == 60)
                    x = 0.5;
                if (x == 90)
                    x = 0;
                if (x == 180)
                    x = -1;
                if (x == 270)
                    x = 0;
            }
            return x;
        }
        static public double Lognat(double x, int n = 1, double znat = 1e-5)
        {
            double t = MathSyst.Power(-1, n + 1) * MathSyst.Power(x - 1, n) / n;
            long b = (long)t;
            if (MathSyst.Abs(t) < 1e-3)
                return t;
            return b + Lognat(x, n + 1, znat);
        }
    }
}
