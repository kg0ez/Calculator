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
using System.Windows.Shapes;

namespace я_и_толя
{
    /// <summary>
    /// Логика взаимодействия для Function.xaml
    /// </summary>
    public partial class Function : Page
    {
        private void Back_to_integral_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());

        }
        public Function()
        {
            InitializeComponent();
        }
    }
}
