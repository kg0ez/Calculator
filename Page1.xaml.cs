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
        public double znachenie;
        public double sqrt234;
        public double step, otvet=0;
        public int quantity = 0, onecomma = 0, Min_Plus = 0,kol=0;
        public string D,D2, N1,N3;
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
            if (sender == comma && onecomma == 0)
            { onecomma++;
                TextB.Text += stroka;
            }
            else if (TextB.Text == "0")
                TextB.Text = "";
            string text = TextB.Text, obrabotka=TextB.Text;
            if (kol==2)
            {
                TextB.Clear();
                kol = 1;
            }
            if (kol==3)
            {
                TextB.Clear();
            }
            if (stroka == "C")
            {
                TextB.Text = "0";
                onecomma = 0;
                kol = 0;
            }
            else if (sender == pi)
            {
                TextB.Clear();
                TextB.Text += "3,141592653589793";
            }
            else if (sender == button_e)
            {
                TextB.Clear();
                TextB.Text += "2,718281828459045";
            }
            else if (sender == POWN || quantity == 1)
            {
                if (quantity == 1)
                {
                    if (sender == back)
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
                        step = step - 2 * step;
                        double ex = 1.0 / MathSyst.Power(znachenie, step);
                        TextB.Text += ex;
                    }
                    else
                        TextB.Text += MathSyst.Power(znachenie, step);
                    quantity = 0;
                }

            }
            else if (sender == cos)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                var grad = znachenie * 3.1415926535897931 / 180;
                TextB.Text += MathSyst.Cos(grad);

            }
            else if (sender == sin)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                var grad = znachenie * 3.1415926535897931 / 180;
                TextB.Text += MathSyst.Sin(grad);
            }
            else if (sender == tg)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                var grad = znachenie * 3.1415926535897931 / 180;
                TextB.Text += MathSyst.Sin(grad) / MathSyst.Cos(grad);
            }
            else if (sender == Ostatok)
            {
                znachenie = Convert.ToDouble(TextB.Text) / 100;
                TextB.Clear();
                TextB.Text += znachenie;
            }
            else if (sender == SQRT2)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.SQRTkv(znachenie);
            }
            else if (sender == Facktorial)
            {
                znachenie = Convert.ToDouble(TextB.Text);
                TextB.Clear();
                TextB.Text += MathSyst.Fack(znachenie);
            }
            else if (sender == back)
            {
                TextB.Clear();
                TextB.Text += MathSyst.Clear(text);
            }
            else if (sender == Delenie)
            {
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += 1.0 / znachenie;
            }
            else if (sender == MINUSorPLUS)
            {
                int i = 1;
                if (Min_Plus == 1 && i == 1)
                {
                    znachenie = -1 * double.Parse(TextB.Text);
                    TextB.Clear();
                    TextB.Text += znachenie;
                    Min_Plus = 0;
                    i--;
                }
                if (Min_Plus == 0 && i == 1)
                {
                    znachenie = double.Parse(TextB.Text);
                    TextB.Text = "-";
                    TextB.Text += znachenie;
                    Min_Plus++;
                }
            }
            else if (sender == addition)
            {
                if (kol==0)
                {
                D = "+";
                TextB.Clear();
                N1 = text;
                    kol++;
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
            else if (sender == minus)
            {

                if (kol == 0)
                {
                    D = "-";
                    TextB.Clear();
                    N1 = text;
                    kol++;
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
            else if (sender == multiply)
            {
                if (kol == 0)
                {
                    D = "*";
                    TextB.Clear();
                    N1 = text;
                    kol++;
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
                }
            }
            else if (sender == division)
            {
                if (kol == 0)
                {
                    D = "/";
                    TextB.Clear();
                    N1 = text;
                    kol++;
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
                }
               
            }
            else if (sender == ln)
            {
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += Lognat(znachenie);
            }
            else if (sender == equally)
            {
                double dn1, dn2, res = 0;
                dn1 = double.Parse(N1);
                if (kol == 3 && D2=="/")
                {
                    kol = 0;
                    znachenie = double.Parse(N3) / double.Parse(text);
                    TextB.Clear();
                    TextB.Text += znachenie;
                }
                else if (kol == 3 && D2 == "*")
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
            else if (sender != comma)
            { TextB.Text += stroka; }

        }
        
        static public double Lognat(double x, int n = 1, double znat = 1e-5)
        {
            var t = MathSyst.Power(-1, n + 1) * MathSyst.Power(x - 1, n) / n;
            if (MathSyst.Abs(t) < 1e-3)
                return t;
            return t + Lognat(x, n + 1, znat);
        }
        //округление
        /* static string Round(string x)
         {
             int legthn = x.Length;
             double y = double.Parse(x);
             double okr = y % 10;
             double r = Clear(y);
             if (okr>=5)
             {

             }
             return x;
         }
        */

    }
}
