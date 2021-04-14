using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace я_и_толя
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    
    public partial class Page1 : Page
    {
        

        private void Расчёт_интегралов_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
            
        }
        public double znachenie;
        public double sqrt234;
        public double step, slogaemoe1 = 0, slogaemoe2 = 0, slogaemoe3 = 0, otvet=0;
        public int quantity =0, onecomma=0;
        public Page1()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;

                }
            }
            TextB.Text = "0";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string stroka = (string)((Button)e.OriginalSource).Content;
            if (sender == comma && onecomma == 0)
            { onecomma++;
                TextB.Text += stroka;
            }
            else if (TextB.Text == "0")
                TextB.Text = "";
            string text = TextB.Text;
            if (stroka == "C")
            { 
                TextB.Text = "0";
                onecomma = 0;
            }
            else if (sender == pi)
                TextB.Text += "3,14";
            else if (sender == button_e)
                TextB.Text += "2,718";
            else if (sender == POWN || quantity == 1)
            {
                if (quantity == 1)
                {
                    if (sender == back)
                    {
                        TextB.Clear();
                        TextB.Text += Clear(text);
                    }
                    else if (stroka != "=")
                        TextB.Text += stroka;
                }
                if (quantity == 0)
                {
                    znachenie = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    quantity++;
                }
                else if (stroka == "=")
                {
                    step = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    if (step < 0)
                    {
                        step = step - 2 * step;
                        double ex = 1.0 / Power(znachenie, step);
                        TextB.Text += ex;
                    }
                    else
                        TextB.Text += Power(znachenie, step);
                    quantity = 0;
                }

            }
            else if (sender == cos)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                var grad = znachenie * 3.1415926535897931 / 180;
                TextB.Text += Cos(grad);

            }
            else if (sender == Ostatok)
            {
                znachenie = Convert.ToDouble(TextB.Text)/100;
                TextB.Clear();
                TextB.Text += znachenie;
            }
            else if (sender == SQRT2)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += SQRTkv(znachenie);
            }
            else if (sender == Facktorial)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += Fack(znachenie);
            }
            else if (sender == back)
            {
                TextB.Clear();
                TextB.Text += Clear(text);
            }
            else if (sender == Delenie)
            {
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += 1.0 / znachenie;
            }
            else if (sender == multiply)
            { 
            
            }
            else if (sender == minus)
            {
            
            }
            else if (sender == addition)
            {

            }
            else if (sender == division)
            {

            }
            else if (sender == equally)
            {
                TextB.Clear();
                TextB.Text += otvet;
            }
            else if (sender != comma)
                TextB.Text += stroka;
            
        }
        //расчёт SQRT
        static public double SQRTkv(double number)
        {
            // number - число по корнем         
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
        //степень
        static double Power(double x, double n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n % 2 == 0)
            {
                var p = Power(x, n / 2);
                return p * p;
            }
            else
            {
                return x * Power(x, n - 1);
            }
        }
        //Очистка
        static string Clear(string value)
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
            var t = Power(-1, n) * Power(x, 2 * n) / Fack((uint)(2 * n));
            if (Abs(t) < precision)
                return t;
            return t + Cos(x, n + 1, precision);
        }
        static double Abs(double num)
        {
            if (num >= 0)
                return num;
            return -num;
        }
        static double Factorial(uint num)
        {
            if (num <= 1)
                return 1d;
            return num * Factorial(num - 1);
        }


    }
}
