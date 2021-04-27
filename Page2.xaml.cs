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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        //Ограничение ввода символов
        private void TextB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender==Trapec_N || sender == Simp_n)
            {
                e.Handled = !((Char.IsDigit(e.Text, 0)));
            }
            else
                e.Handled = !((Char.IsDigit(e.Text, 0) || ((e.Text == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString()) && (DS_Count(((TextBox)sender).Text) < 1))));
        }

        public int DS_Count(string s)
        {
            string substr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString();
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }


        //Переход на Page1
        private void But1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        //Вывод справки
        private void GetHelp_Click(object sender, RoutedEventArgs e)
        {
            new Support_integrals().ShowDialog();
        }

        //Расчёт методом трапеций
        public static double TrapecMethod(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = MathSyst.Func(a) + MathSyst.Func(b);
            for (int i = 0; i <= n - 1; i++)
            {
                sum += 2 * MathSyst.Func(a + i * h);
            }
            sum *= h / 2;
            return sum;

        }
        //Метод симпсона
        public static double SimpsonMethod(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = MathSyst.Func(a)+MathSyst.Func(b);
            int k;
            for (int i = 0; i <= n - 1; i++)
            {
                k = 2 + 2 * (i % 2);
                sum += k * MathSyst.Func(a + i * h);
            }
            sum *= h / 3;
            return sum;
        
        }

        //Расчёт методом трапеций
        private void Button_Trapec(object sender, RoutedEventArgs e)
        {

            if (TrBut.IsChecked == true)
            {
                PgTwo_Text.Text = Convert.ToString(TrapecMethod(Convert.ToDouble(Trapec_a.Text), Convert.ToDouble(Trapec_B.Text), Convert.ToInt32(Trapec_N.Text)));
            }
            else if (Trapec_a.Text == "" || Trapec_B.Text == "" || Trapec_N.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                MessageBox.Show("Вы не выбрали метод Трапеций");
            }
        }

        //Расчёт методом симпсона
        private void Button_Simpson(object sender, RoutedEventArgs e)
        {
            if (SimpBut.IsChecked == true)
            {
                PgTwo_Text.Text = Convert.ToString(SimpsonMethod(Convert.ToDouble(Simp_a.Text), Convert.ToDouble(Simp_b.Text), Convert.ToInt32(Simp_n.Text)));
            }
            else if (Simp_a.Text==""||Simp_b.Text==""|| Simp_n.Text=="")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                MessageBox.Show("Вы не выбрали метод Симпсона");
            }

        }

        //Выезжающий список
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (f1.IsSelected == true)
            {
                MathSyst.i = 1;
            }
            else if(f2.IsSelected == true)
            {
                MathSyst.i = 2;
            }
            else if(f3.IsSelected == true)
            {
                MathSyst.i = 3;
            }
            else if (f4.IsSelected == true)
            {
                MathSyst.i = 4;
            }
            else if (f5.IsSelected == true)
            {
                MathSyst.i = 5;
            }
            else if (f6.IsSelected == true)
            {
                MathSyst.i = 6;
            }
            else if (f7.IsSelected == true)
            {
                MathSyst.i = 7;
            }
            else if (f8.IsSelected == true)
            {
                MathSyst.i = 8;
            }
        }
    }
}
