using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public double znachenie,value, step;
        public int quantity = 0, onecomma = 0,kol=0,g=0, sqrtchisl=0;
        public string D,D2, N1,N3;
        public bool entrance = false, slog = false;
        public double PI = 3.141592653589793, E= 2.718281828459045;
        public Page1()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is System.Windows.Controls.Button)
                {
                    ((System.Windows.Controls.Button)el).Click += Button_Click;

                }
            }
            TextB.Text = "0";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string stroka = (string)((System.Windows.Controls.Button)e.OriginalSource).Content;
            if (sender == comma && onecomma == 0) //Работа с нулями
            { 
                onecomma++;
                TextB.Text += stroka;
            }
            else if (TextB.Text == "0")
                TextB.Text = "";
            string text = TextB.Text;
            if (slog == true)
            {
                TextB.Clear();
                D2 = D;
            }
            if (kol == 2)//Выполнение арифметических операций, если одинаковое действия
            {
                TextB.Clear();
                kol = 1;
            }
            if (kol == 3)//Выполнение арифметических операций, если разные действия
                TextB.Clear();
            if (stroka == "C") //Очистка значения 
            {
                TextB.Text = "0";
                quantity = 0; onecomma = 0;  kol = 0;  g = 0; sqrtchisl = 0;
                znachenie = 0; value = 0; step=0;
                entrance = false; slog = false;
                D = ""; D2 = ""; N1 = ""; N3="";
            }
            else if (sender == pi) //Число PI
            {
                TextB.Clear();
                TextB.Text += PI;
            }
            else if (sender == button_e) //Число E
            {
                TextB.Clear();
                TextB.Text += E;
            }
            else if (sender == POWN || quantity == 1) //Возведение в степень
            {
                if (quantity == 1)
                {
                    if (sender == MINUSorPLUS) //Постановка "+" или "-" перед числом
                    {
                        value = double.Parse(TextB.Text);
                        TextB.Clear();
                        TextB.Text += MathSyst.MorP(value);
                    }
                    else if (sender == back)
                    {
                        TextB.Clear();
                        TextB.Text += MathSyst.Clear(text);
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
                    step = Convert.ToInt32(TextB.Text);
                    TextB.Clear();
                    if (step < 0)
                    {
                        step = -1*step;
                        double ex = 1.0 / MathSyst.Power(znachenie, step);
                        TextB.Text += ex;
                    }
                    else
                        TextB.Text += MathSyst.Power(znachenie, step);
                    quantity = 0;
                }

            }
            
            else if (sender == cos) //COS
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                var grad = znachenie * PI / 180;
                TextB.Text += MathSyst.Cos(grad);

            }
            else if (sender == sin) //SIN
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                var grad = znachenie * PI / 180;
                TextB.Text += MathSyst.Sin(grad);
            }
            else if (sender == tg) //tg
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                var grad = znachenie * PI / 180;
                TextB.Text += MathSyst.Sin(grad) / MathSyst.Cos(grad);
            }
            else if (sender == Ostatok) //Деление на 100
            {
                znachenie = Convert.ToDouble(TextB.Text) / 100;
                TextB.Clear();
                TextB.Text += znachenie;
            }
            else if (sender == SQRT2) //Квадратный корень
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.SQRTkv(znachenie);
            }
            else if (sender == SQRT3) //Корень в третьей степени
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.SqrtN(3, znachenie);
            }
            else if (sender == SQRT4) //Корень в четвёртой степени
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.SQRTkv(znachenie);
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.SQRTkv(znachenie);
            }
            else if (sender == SQRTN || sqrtchisl == 1) //Корень из N
            {
                if (sqrtchisl == 1)
                {

                    if (sender == back)
                    {
                        TextB.Clear();
                        TextB.Text += MathSyst.Clear(text);
                    }
                    else if (stroka != "=")
                        TextB.Text += stroka;
                }
                if (sqrtchisl == 0)
                {
                    znachenie = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    sqrtchisl++;
                }
                else if (stroka == "=")
                {
                    step = Convert.ToInt32(TextB.Text);
                    TextB.Clear();
                    TextB.Text += MathSyst.SqrtN(step, znachenie);
                    sqrtchisl = 0;
                }
            }
            else if (sender == Facktorial) //Факториал
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.Fack(znachenie);
            }
            else if (sender == back) //Очистить последний ввод
            {
                TextB.Clear();
                TextB.Text += MathSyst.Clear(text);
            }
            else if (sender == Delenie) //Деление на один
            {
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += 1.0 / znachenie;
            }
            else if (sender == MINUSorPLUS) //Постановка "+" или "-" перед числом
            {
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.MorP(znachenie);
            }
            else if (sender == addition) //Сложение
            {
                if (kol==0)
                {
                D = "+";
                TextB.Clear();
                N1 = text;
                    kol++;
                }
                else if(entrance==true)
                {
                    double dn1, dn2, res = 0;
                    dn1 = double.Parse(N1);
                    if ((kol == 3 && D2 == "/") || (entrance == true && D2 == "/"))
                    {
                        kol = 0;
                        znachenie = double.Parse(N3) / double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                    }
                    else if ((kol == 3 && D2 == "*") || (entrance == true && D2 == "*"))
                    {
                        kol = 0;
                        znachenie = double.Parse(N3) * double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                    }
                    if (TextB.Text == "")
                    {
                        TextB.Text = text;
                        D = D2;
                    }
                    dn2 = double.Parse(TextB.Text);
                    if (D == "-" || D == "*" || D == "+" || D == "/")
                    {
                        TextB.Clear();
                        if (D == "-")
                            res = dn1 - dn2;
                        else if (D == "*")
                            res = dn1 * dn2;
                        else if (D == "/")
                            res = dn1 / dn2;
                        else if (D == "+")
                            res = dn1 + dn2;
                        TextB.Text += res;
                    }
                    kol = 1;
                    D = "+";
                    N1 = TextB.Text;
                    slog = true;
                }
                else if(kol==1)
                {
                    D2 = "+";
                    if (D==D2)
                    {
                        kol++;
                        znachenie = double.Parse(N1)+double.Parse(text);
                    TextB.Clear();
                        TextB.Text += znachenie;
                        N1 = TextB.Text;
                    }
                    else if (D!=D2 && D2=="+")
                    {
                        kol+=2;
                        if (D=="*")
                        znachenie = double.Parse(N1) * double.Parse(text);
                        else if(D=="/")
                        znachenie = double.Parse(N1) / double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                        N1 = TextB.Text;
                    }
                }

            }
            else if (sender == minus) //Вычетание
            {

                if (kol == 0)
                {
                    D = "-";
                    TextB.Clear();
                    N1 = text;
                    kol++;
                }
                else if (entrance == true)
                {
                    double dn1, dn2, res = 0;
                    dn1 = double.Parse(N1);
                    if ((kol == 3 && D2 == "/") || (entrance == true && D2 == "/"))
                    {
                        kol = 0;
                        znachenie = double.Parse(N3) / double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                    }
                    else if ((kol == 3 && D2 == "*") || (entrance == true && D2 == "*"))
                    {
                        kol = 0;
                        znachenie = double.Parse(N3) * double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                    }
                    if (TextB.Text == "")
                    {
                        TextB.Text = text;
                        D = D2;
                    }
                    dn2 = double.Parse(TextB.Text);
                    if (D == "-" || D == "*" || D == "+" || D == "/")
                    {
                        TextB.Clear();
                        if (D == "-")
                            res = dn1 - dn2;
                        else if (D == "*")
                            res = dn1 * dn2;
                        else if (D == "/")
                            res = dn1 / dn2;
                        else if (D == "+")
                            res = dn1 + dn2;
                        TextB.Text += res;
                    }
                    kol = 1;
                    D = "-";
                    N1 = TextB.Text;
                    slog = true;
                }
                else if (kol == 1)
                {
                    D2 = "-";
                    if (D == D2)
                    {
                        kol++;
                        znachenie = double.Parse(N1) - double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                        N1 = TextB.Text;
                        step = Convert.ToDouble(TextB.Text);

                    }
                    else if (D != D2 && D2 == "-")
                    {
                        kol += 2;
                        if (D == "*")
                            znachenie = double.Parse(N1) * double.Parse(text);
                        else if (D == "/")
                            znachenie = double.Parse(N1) / double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                        N1 = TextB.Text;
                    }

                }
            }
            else if (sender == multiply) //Умножение
            {
                if (kol == 0)
                {
                    D = "*";
                    TextB.Clear();
                    N1 = text;
                    kol++;
                }
                else if ((D != D2) && g == 1 && kol!=1)
                {
                    znachenie = double.Parse(N3) * double.Parse(text);
                    g = 0;
                    kol = 2;
                    TextB.Clear();
                    TextB.Text += znachenie;
                    N3 = TextB.Text;
                    entrance = true;
                    D2 = "*";

                }
                else if (kol == 1)
                {
                    D2 = "*";
                    if (D == D2)
                    {
                        kol++;
                          znachenie = double.Parse(N1) * double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                        N1 = TextB.Text;
                    }
                    else if (D != D2)
                    {
                        kol += 2;
                        N3 = text;
                    }
                    entrance = true;

                }
                g++;


            }
            else if (sender == division) //Деление
            {
                if (kol == 0)
                {
                    D = "/";
                    TextB.Clear();
                    N1 = text;
                    kol++;
                }
                else if ((D != D2) && g == 1)
                {
                    znachenie = double.Parse(N3) * double.Parse(text);
                    g = 0;
                    kol = 2;
                    TextB.Clear();
                    TextB.Text += znachenie;
                    N3 = TextB.Text;
                    entrance = true;
                    D2 = "/";

                }
                else if (kol == 1)
                {
                    D2 = "/";
                    if (D == D2)
                    {
                        kol++;
                        znachenie = double.Parse(N1) / double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                        N1 = TextB.Text;
                    }
                    
                    else if (D!=D2)
                    {
                        kol += 2;
                        N3 = text;
                    }
                    entrance = true;

                }
                g++;
               
            }
            else if (sender == equally) //Расчёт всех значений
            {
                double dn1, dn2, res = 0;
                dn1 = double.Parse(N1);
                if ((kol == 3 && D2=="/")|| (entrance == true && D2 == "/"))
                {
                    kol = 0;
                    znachenie = double.Parse(N3) / double.Parse(text);
                    TextB.Clear();
                    TextB.Text += znachenie;
                }
                else if ((kol == 3 && D2 == "*")|| (entrance == true && D2 == "*"))
                {
                    kol = 0;
                    znachenie = double.Parse(N3) * double.Parse(text);
                    TextB.Clear();
                    TextB.Text += znachenie;
                }
                if (TextB.Text=="")
                {
                    TextB.Text = text;
                    D = D2;
                }
                dn2 = double.Parse(TextB.Text);
                if (D == "-" || D == "*"|| D == "+" || D == "/")
                {
                    TextB.Clear();
                    if (D == "-")
                        res = dn1 - dn2;
                    else if (D == "*")
                        res = dn1 * dn2;
                    else if (D == "/")
                        res = dn1 / dn2;
                    else if (D == "+")
                        res = dn1 + dn2;
                    TextB.Text += res;
                }
                kol = 0;
            }
            else if (sender == ln) //Натуральный логорифм 
            {
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += Math.Log(znachenie);
            }
            else if (sender == lg) //Десятичный логорифм
            {
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += Math.Log10(znachenie);
            }
            else if (sender != comma) //Ввод на экран
            { TextB.Text += stroka; }

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
