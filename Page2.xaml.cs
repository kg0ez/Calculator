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

        private void But1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
        static double Func(double x)
        {
            return 1 / Math.Log(x);
        }

        //Расчёт методом трапеций
        public static double TrapecMethod(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                sum += 2 * Func(a + i * h);
            }
            sum *= h / 2;
            return sum;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TrBut.IsChecked == true)
            {
                PgTwo_Text.Text = Convert.ToString(TrapecMethod(Convert.ToDouble(Trapec_a.Text), Convert.ToDouble(Trapec_B.Text), Convert.ToInt32(Trapec_N.Text)));
            }
        }
    }
}
