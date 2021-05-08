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
using Кaлькулятор;

namespace я_и_толя
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SplashScreen splashScreen = new SplashScreen("Images/iconfinder_calculator_1291736.png");
            splashScreen.Show(true);
            InitializeComponent();
            MainFrame.Content = new Page1();

        }
        
    }
}
