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
        

        //Ограничение ввода символов
        public int DS_Count(string s)
        {
            string substr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString();
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }
        private void TextB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !((Char.IsDigit(e.Text, 0) || ((e.Text == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString()) && (DS_Count(((TextBox)sender).Text) < 1))));
        }
        public double znachenie; //Кратковременное запоминание значение, над которым надо выполнить действие в данный момент
        public double value; //Поставить "+/-" значению степени
        public double step = 0; //Переменная запоминает степень в которую нужно возвести число
        public double znach_sin; //Расчёт синуса, для расчёта тангенса
        public double znach_cos; //Расчёт косинуса, для расчёта тангенса
        public int quantity = 0; //Для входа в возведение в степень
        public int onecomma = 0; //Поставить одну запятую, если не целое число 
        public int kol = 0; //Шаг действий, запоминание значений
        public int g = 0; //Для входы в условие
        public int sqrtchisl = 0; //Для входа вычесления корня из "N"
        public int shag = 0; //Для входы в условие и записи многозначного числа
        public int razndeistv = 0; //Для выполнения разных действий
        public int doubleznak = 0; //Переписать знак, если случайно нажали не на тот
        public int ymno = 0; //Записываем знак умножить, если обходимо
        public int delenn =0; //Записываем знак деление, если обходимо
        public string D; //Переменная запоминает первый знак
        public string D2; //Переменная запоминает второй знак
        public string N1; //Переменная запоминает первое число
        public string N3; //Переменная запоминает второе число, если это необходимо
        public bool entrance = false; //Вход в условие, где первое действие сложение (разность), а второе деление (умножить)
        public bool slog = false; //Изменение действия
        public double PI = 3.141592653589793, E= 2.718281828459045;//математические постоянные
        public Page1()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children) //Считывание клавишь калькулятора
            {
                if (el is System.Windows.Controls.Button)
                {
                    ((System.Windows.Controls.Button)el).Click += Button_Click;

                }
            }
            TextB.Text = "0";//Ввод на экран калькулятора, при старте программы
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Взаимодействие с кнопками 
        {
            string stroka = (string)((System.Windows.Controls.Button)e.OriginalSource).Content;
            if (sender == comma && onecomma == 0) //Работа с нулями
            {
                onecomma++; 
                TextB.Text += stroka; //Запись одной запятой в строку
            }
            else if (TextB.Text == "0") //Обработка ввода 0
                TextB.Text = "";
            string text = TextB.Text; // Присваивание переменой текстовую строку
            if (slog == true)//Для смены второго знака на первый 
            {
                TextB.Clear();
                D2 = D;
                slog = false;
            }
            if (kol == 2)//Выполнение арифметических операций, если одинаковое действия
            {
                TextB.Clear();
                kol = 1;
            }
            if (kol == 3 && shag == 1)//Выполнение арифметических операций, если разные действия
            {
                kol = 1;
                TextB.Clear();
                shag--;
            }
            if (stroka == "C") //Очистка значения 
            {
                TextB.Text = "0";
                quantity = 0; onecomma = 0; kol = 0; g = 0; sqrtchisl = 0; shag = 0; doubleznak = 0;
                znachenie = 0; value = 0; step = 0; razndeistv = 0; ymno = 0; delenn = 0;
                entrance = false; slog = false;
                D = ""; D2 = ""; N1 = ""; N3 = "";
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
                try
                {
                    if (quantity == 1)
                    {
                        if (sender == MINUSorPLUS) //Постановка "+" или "-" перед числом
                        {
                            if (TextB.Text != "")//Текст не должен быть пустой и равным нулю
                            {
                                value = double.Parse(TextB.Text);
                                TextB.Clear();
                                TextB.Text += MathSyst.MorP(value);
                            }
                        }
                        else if (sender == back)//Удаление одного значение степени
                        {
                            TextB.Clear();
                            TextB.Text += MathSyst.Clear(text);
                        }
                        else if (stroka != "=" && stroka!=",")//Присвоение строке значения, пока не будет задействована клавиша "="
                            TextB.Text += stroka;
                    }
                    if (quantity == 0)//Запоминание числа, которого нужно возвести в степень
                    {
                        znachenie = Convert.ToDouble(TextB.Text);
                        TextB.Clear();
                        quantity++;
                    }
                    else if (stroka == "=")//Возведение
                    {
                        step = Convert.ToDouble(TextB.Text);
                        TextB.Clear();
                        if (step < 0)//Если степень отрицательная
                        {
                            step = -1 * step;
                            double ex = 1.0 / MathSyst.Power(znachenie, step);
                            TextB.Text += ex;
                        }
                        else//Положительная стпень 
                            TextB.Text += MathSyst.Power(znachenie, step);
                        quantity = 0;
                    }
                }
                catch
                { TextB.Text = "0"; }

            }
            else if (sender == cos) //Расчёт косинуса
            {
                if (TextB.Text == "")
                    TextB.Text = "0";
                int s = 1;
                znachenie = Convert.ToDouble(TextB.Text);
                double tabl_znach = MathSyst.Cos_Sin(znachenie, s);
                TextB.Clear();
                if (znachenie == tabl_znach)
                {
                    var grad = znachenie * PI / 180;
                    TextB.Text += MathSyst.Cos(grad);
                }
                else
                    TextB.Text += tabl_znach;
            }
            else if (sender == sin) //Расчёт синуса
            {
                if (TextB.Text == "")
                    TextB.Text = "0";
                int s = 0;
                znachenie = Convert.ToDouble(TextB.Text);
                double tabl_znach = MathSyst.Cos_Sin(znachenie, s);
                TextB.Clear();
                if (znachenie == tabl_znach)
                {
                    var grad = znachenie * PI / 180;
                    TextB.Text += MathSyst.Sin(grad);
                }
                else
                    TextB.Text += tabl_znach;
            }
            else if (sender == tg) //Расчёт тангенса 
            {
                if (TextB.Text == "")
                    TextB.Text = "0";
                int s = 0;
                znachenie = Convert.ToDouble(TextB.Text);
                double tabl_znach = MathSyst.Cos_Sin(znachenie, s);
                TextB.Clear();
                if (znachenie == tabl_znach)
                {
                    var grad = znachenie * PI / 180;
                    znach_sin = MathSyst.Sin(grad);
                }
                else
                    znach_sin = Convert.ToDouble(tabl_znach);
                s = 1;
                tabl_znach = MathSyst.Cos_Sin(znachenie, s);
                TextB.Clear();
                if (znachenie == tabl_znach)
                {
                    var grad = znachenie * PI / 180;
                    znach_cos = MathSyst.Cos(grad);
                }
                else
                    znach_cos = Convert.ToDouble(tabl_znach);
                TextB.Text += znach_sin/znach_cos;
                if (znachenie == 45)
                    TextB.Text = "1";
                if (TextB.Text == "∞" || TextB.Text == "-∞")
                    TextB.Text = "Тангенс такого угла не существует";
            }
            else if (sender == Ostatok) //Деление на 100
            {
                if (TextB.Text == "")
                    TextB.Text = "0";
                znachenie = Convert.ToDouble(TextB.Text) / 100;
                TextB.Clear();
                TextB.Text += znachenie;
            }
            else if (sender == SQRT2) //Квадратный корень
            {
                try
                {
                    znachenie = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    TextB.Text += MathSyst.SQRTkv(znachenie);
                }
                catch
                { TextB.Text = "0"; }
            }
            else if (sender == SQRT3) //Корень в третьей степени
            {
                try {
                    znachenie = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    TextB.Text += MathSyst.SqrtN(3, znachenie); }
                catch
                { TextB.Text = "0"; }
            }
            else if (sender == SQRT4) //Корень в четвёртой степени
            {
                try
                {
                    znachenie = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    TextB.Text += MathSyst.SQRTkv(znachenie);
                    znachenie = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    TextB.Text += MathSyst.SQRTkv(znachenie);
                }
                catch
                { TextB.Text = "0"; }
            }
            else if (sender == SQRTN || sqrtchisl == 1) //Корень из N
            {
                try { 
                if (sqrtchisl == 1)
                {

                    if (sender == back)//Удаление одного значение степени
                    {
                        TextB.Clear();
                        TextB.Text += MathSyst.Clear(text);
                    }
                    else if (stroka != "=")//Присвоение строке значения, пока не будет задействована клавиша "="
                        TextB.Text += stroka;
                }
                if (sqrtchisl == 0)//Запоминание числа под корнем
                {
                    znachenie = Convert.ToDouble(TextB.Text);
                    TextB.Clear();
                    sqrtchisl++;
                }
                else if (stroka == "=")//Расчёт корня
                {
                    step = Convert.ToInt32(TextB.Text);
                    TextB.Clear();
                    TextB.Text += MathSyst.SqrtN(step, znachenie);
                    sqrtchisl = 0;
                } }
                catch
                { TextB.Text = "0"; }
            }
            else if (sender == Facktorial) //Факториал
            {
                if (TextB.Text == "")
                    TextB.Text = "0";
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
                try
                { znachenie = double.Parse(TextB.Text); 
                 TextB.Clear();
                TextB.Text += 1.0 / znachenie; }
                catch
                { TextB.Text = "Деление на ноль невозможно"; }
            }
            else if (sender == MINUSorPLUS) //Постановка "+" или "-" перед числом
            {
                if (TextB.Text != "")//Постановка "+" или "-" перед числом
                {
                    znachenie = double.Parse(TextB.Text);
                    TextB.Clear();
                    TextB.Text += MathSyst.MorP(znachenie);
                }
                else//если значение равно "0", то знак "-" не будет
                    TextB.Text = "0";
            }
            else if (sender == addition) //Сложение
            {

                if (doubleznak >= 1)
                {
                    if (kol == 0)//Запоминание первого действия
                    {
                        if (text == "")
                            text = "0";
                        D = "+";   //Первый знак
                        TextB.Clear();
                        N1 = text;  //Первое число
                        kol++;
                    }
                    else if (entrance == true)//Расчёт значения, если первое "+", а второе "*" или "/"
                    {
                        if (text == "")
                            text = "0";
                        double dn1, dn2, res = 0;
                        dn1 = double.Parse(N1);
                        if (ymno == 42)
                            D2 = "*";
                        if (delenn == 47)
                            D2 = "/";
                        if ((kol == 1 && D2 == "/") || (entrance == true && D2 == "/"))//Выполнения деления
                        {
                            kol = 0;
                            if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                                znachenie = double.Parse(N1) / double.Parse(text);
                            else//Расчёт по третьему числу
                                znachenie = double.Parse(N3) / double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            if (text == "0")
                                TextB.Text = "Деление на ноль невозможно";
                            D2 = "";
                        }
                        else if ((kol == 1 && D2 == "*") || (entrance == true && D2 == "*"))//Выполнения умножения
                        {
                            kol = 0;
                            if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                                znachenie = double.Parse(N1) * double.Parse(text);
                            else//Расчёт по третьему числу
                                znachenie = double.Parse(N3) * double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            D2 = "";
                        }
                        if (razndeistv == 1)//Если дребуется выполнение разных действий
                        {
                            try
                            {
                                if (TextB.Text == "")//Если значение равно 0
                                {
                                    TextB.Text = text;
                                    if (D2 != null && D2 != "")//В отсуствии второго действия, выполнения первого
                                        D = D2;
                                }
                                if (TextB.Text == "" && D != "/")//Значение равно 0, при отсуствии деления
                                    TextB.Text = "0";
                                dn2 = double.Parse(TextB.Text);
                                if (D == "-" || D == "*" || D == "+" || D == "/")//Расчёт действий
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
                                razndeistv = 0;
                            }
                            catch { TextB.Text = "Деление на ноль невозможно"; }
                        }
                        kol = 1;
                        D = "+";
                        N1 = TextB.Text;//Запоминание
                        slog = true;//Запись значения
                        entrance = false;
                    }
                    else if (kol == 1)//Второе действие
                    {

                        if (text == "")
                            text = "0";
                        D2 = "+"; //Второй знак
                        if (D == D2)//Сравнение первого и второго действия
                        {
                            kol++;
                            znachenie = double.Parse(N1) + double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            N1 = TextB.Text;//Запоминания результата первым значениям 
                        }
                        else if (D != D2 && D2 == "+")//Выполнение первого действия, если второе действие  - сложение
                        {

                            kol += 2; //Переход к записи следующего значения
                            shag = 1; //Записать следующее многозначное число
                            if (D == "*")//Если умножение
                                znachenie = double.Parse(N1) * double.Parse(text);
                            else if (D == "/")//Если деление
                                znachenie = double.Parse(N1) / double.Parse(text);
                            else if (D == "-")//Если разность
                                znachenie = double.Parse(N1) - double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            if (D == "/" && text == "0")
                                TextB.Text = "Деление на ноль невозможно";
                            D = "+";//Изменения первого знака
                            N1 = TextB.Text;//Запоминания результата первым значениям }
                        }

                    }
                    onecomma = 0;
                    doubleznak = 0;
                }
                else
                {
                    if (D2 == "" || D2==null)
                        D = "+";
                    else
                        D2 = "+";
                }
            }
            else if (sender == minus) //Вычитание
            {
                if (doubleznak >= 1) { 
                if (kol == 0)//Запоминание первого действия
                {
                    if (text == "")
                        text = "0";
                    D = "-";   //Первый знак
                    TextB.Clear();
                    N1 = text;  //Первое число
                    kol++;
                }
                else if (entrance == true)//Расчёт значения, если первое "-", а второе "*" или "/"
                {
                    if (text == "")
                        text = "0";
                    double dn1, dn2, res = 0;
                        if (ymno == 42)
                            D2 = "*";
                        if (delenn == 47)
                            D2 = "/";
                        dn1 = double.Parse(N1);
                    if ((kol == 1 && D2 == "/") || (entrance == true && D2 == "/"))//Выполнения деления
                    {
                        kol = 0;
                        if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                            znachenie = double.Parse(N1) / double.Parse(text);
                        else//Расчёт по третьему числу
                            znachenie = double.Parse(N3) / double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                            if (text == "0")
                                TextB.Text = "Деление на ноль невозможно";
                            D2 = "";
                    }
                    else if ((kol == 1 && D2 == "*") || (entrance == true && D2 == "*"))//Выполнения умножения
                    {
                        kol = 0;
                        if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                            znachenie = double.Parse(N1) * double.Parse(text);
                        else//Расчёт по третьему числу
                            znachenie = double.Parse(N3) * double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                            D2 = "";
                    }
                    if (razndeistv == 1)//Если дребуется выполнение разных действий
                    {
                            try
                            {
                                if (TextB.Text == "")//Если значение равно 0
                                {
                                    TextB.Text = text;
                                    if (D2 != null && D2 != "")//В отсуствии второго действия, выполнения первого
                                        D = D2;
                                }
                                if (TextB.Text == "" && D != "/")//Значение равно 0, при отсуствии деления
                                    TextB.Text = "0";
                                dn2 = double.Parse(TextB.Text);
                                if (D == "-" || D == "*" || D == "+" || D == "/")//Расчёт действий
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
                                razndeistv = 0;
                            }
                            catch { TextB.Text = "Деление на ноль невозможно"; }
                    }
                    kol = 1;
                    D = "-";
                    N1 = TextB.Text;//Запоминание
                    slog = true;//Запись значения
                    entrance = false;
                }
                else if (kol == 1)//Второе действие
                {
                    if (text == "")
                        text = "0";

                    D2 = "-"; //Второй знак
                        if (D == D2)//Сравнение первого и второго действия
                        {
                            kol++;
                            znachenie = double.Parse(N1) - double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            N1 = TextB.Text;//Запоминания результата первым значениям 
                        }
                        else if (D != D2 && D2 == "-")//Выполнение первого действия, если второе действие  - разность
                        {
                            kol += 2; //Переход к записи следующего значения
                            shag = 1; //Записать следующее многозначное число
                            if (D == "*")//Если умножение
                                znachenie = double.Parse(N1) * double.Parse(text);
                            else if (D == "/")//Если деление
                                    znachenie = double.Parse(N1) / double.Parse(text);
                            else if (D == "+")//Если сложение
                                znachenie = double.Parse(N1) + double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            if (D == "/" && text == "0")
                                TextB.Text = "Деление на ноль невозможно";
                            D = "-";//Изменения первого знака
                            N1 = TextB.Text;//Запоминания результата первым значениям 
                        }
                    
                }
                onecomma = 0;
                doubleznak = 0;
                }
                else
                {
                    if (D2 == "" || D2==null)
                        D = "-";
                    else
                        D2 = "-";
                }
            }
            else if (sender == multiply) //Умножение
            {
                if (doubleznak >= 1)
                {
                    if (kol == 0)//Запоминание первого действия
                    {
                        if (text == "")
                            text = "0";
                        D = "*";//Первый знак
                        TextB.Clear();
                        N1 = text;//Первое число
                        kol++;
                    }
                    else if (((D != D2) && g == 1) && (D == "+" || D2 == "+" || D == "-" || D2 == "-"))//Разные знаки, умножение трерьего числа с данным числом
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
                    else if (entrance == true)//Расчёт значения, если первое "+", а второе "*" или "/"
                    {
                        D2 = "*";
                        ymno = 42;
                        if (text == "")
                            text = "0";
                        if ((kol == 1 && D2 == "/") || (entrance == true && D2 == "/"))//Выполнения деления
                        {
                            kol = 2;
                            if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                                znachenie = double.Parse(N1) / double.Parse(text);
                            else//Расчёт по третьему числу
                                znachenie = double.Parse(N3) / double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            if (text == "0")
                                TextB.Text = "Деление на ноль невозможно";
                            D2 = "";
                        }
                        else if ((kol == 1 && D2 == "*") || (entrance == true && D2 == "*"))//Выполнения умножения
                        {
                            kol = 2;
                            if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                                znachenie = double.Parse(N1) * double.Parse(text);
                            else//Расчёт по третьему числу
                                znachenie = double.Parse(N3) * double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            D2 = "";
                        }
                        N3 = TextB.Text;
                    }
                    else if (kol == 1)//Второе действие
                    {
                        if (text == "")
                            text = "0";
                        D2 = "*";//Второй знак
                        if (D == D2)//Если одинаковые знаки
                        {
                            kol++;
                            znachenie = double.Parse(N1) * double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            N1 = TextB.Text;
                        }
                        else if (D != D2 && D == "/")
                        {
                            if (text != "0")
                            {
                                kol++;
                                znachenie = double.Parse(N1) / double.Parse(text);
                                TextB.Clear();
                                TextB.Text += znachenie;
                                N1 = TextB.Text;
                                D = "*";
                            }
                            else if (text == "0")
                                TextB.Text = "Деление на ноль невозможно";
                        }
                        else if (D != D2)//Разные знаки
                        {
                            kol += 2;
                            shag = 1;
                            N3 = text;//Третье значение
                            razndeistv = 1;
                        }
                        entrance = true;//Активация расчёта

                    }
                    onecomma = 0;
                    g++;
                    doubleznak = 0;
                }
                else
                {
                    if (D2 == "" || D2 == null)
                        D = "*";
                    else
                        D2 = "*";
                }

            }
            else if (sender == division) //Деление
            {
                if (doubleznak >= 1) { 
                if (kol == 0)//Запоминание первого действия
                {
                    if (text == "")
                        text = "0";
                    D = "/";//Первый знак
                    TextB.Clear();
                    N1 = text;//Первое число
                    kol++;
                }
                else if (((D != D2) && g == 1)&& (D == "+" || D2 == "+" || D == "-" || D2 == "-"))//Разные знаки, умножение трерьего числа с данным числом
                {
                    znachenie = double.Parse(N3) / double.Parse(text);
                    g = 0;
                    kol = 2;
                    TextB.Clear();
                    TextB.Text += znachenie;
                    N3 = TextB.Text;
                    entrance = true;
                    D2 = "/";

                }
                    else if (entrance == true)//Расчёт значения, если первое "+", а второе "*" или "/"
                    {
                        D2 = "*";
                        delenn = 47;
                        if (text == "")
                            text = "0";
                        if ((kol == 1 && D2 == "/") || (entrance == true && D2 == "/"))//Выполнения деления
                        {
                            kol = 2;
                            if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                                znachenie = double.Parse(N1) / double.Parse(text);
                            else//Расчёт по третьему числу
                                znachenie = double.Parse(N3) / double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            if (text == "0")
                                TextB.Text = "Деление на ноль невозможно";
                            D2 = "";
                        }
                        else if ((kol == 1 && D2 == "*") || (entrance == true && D2 == "*"))//Выполнения умножения
                        {
                            kol = 2;
                            if (razndeistv == 0)//Расчёт, если нет в памяти третьего числа
                                znachenie = double.Parse(N1) * double.Parse(text);
                            else//Расчёт по третьему числу
                                znachenie = double.Parse(N3) * double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            D2 = "";
                        }
                        N3 = TextB.Text;
                    }
                    else if (kol == 1)//Второе действие
                {
                    
                    D2 = "/";//Второй знак
                    if (D == D2)//Если одинаковые знаки
                    {
                            try
                            {
                                kol++;
                                znachenie = double.Parse(N1) / double.Parse(text);
                                TextB.Clear();
                                TextB.Text += znachenie;
                                N1 = TextB.Text;
                            }
                            catch
                            { TextB.Text = "Деление на ноль невозможно"; }
                        }
                    else if (D != D2 && D == "*")
                    {
                            kol++;
                            znachenie = double.Parse(N1) * double.Parse(text);
                            TextB.Clear();
                            TextB.Text += znachenie;
                            N1 = TextB.Text;
                            D = "*";
                    }
                    else if (D != D2)//Разные знаки
                    {
                        kol += 2;
                        shag = 1;
                        N3 = text;//Третье значение
                        razndeistv = 1;
                    }
                    entrance = true;//Активация расчёта

                }
                onecomma = 0;
                g++;//переменная для входа в условия деления умножения
                    doubleznak = 0;
                }
                else
                {
                    if (D2 == "" || D2==null)
                        D = "/";
                    else
                        D2 = "/";
                }
            }
            else if (sender == equally) //Расчёт всех значений
            {
                try { 
                    double dn1, dn2, res = 0;
                    if (N1 == "")//Первое значине равно 0
                        N1 = "0";
                    dn1 = double.Parse(N1);
                
                try
                {
                    if ((kol == 3 && D2 == "/"&&D!="*" && D2 != "*" && D != "/") || (entrance == true && D2 == "/" && D != "*" && D2 != "*" && D != "/"))//Выполнение второго действия, если это деление
                    {
                        kol = 0;
                            if (N3 == null)
                                N3 = "0";
                            znachenie = double.Parse(N3) / double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                    }
                    else if ((kol == 3 && D2 == "*" && D != "/" && D2 != "/" && D != "*") || (entrance == true && D2 == "*" && D != "*" && D2 != "/" && D != "/"))//Выполнение второго действия, если это умножение
                    {
                        kol = 0;
                        if (text == "" )//Последнее значение равно 0
                            text = "0";
                            if (N3 == null)
                                N3 = "0";
                        znachenie = double.Parse(N3) * double.Parse(text);
                        TextB.Clear();
                        TextB.Text += znachenie;
                    }
                    if (TextB.Text == "")//Значение равно 0
                    {
                        TextB.Text = text;
                        if (D2 != null && D2 != "")//Изменение первого действия
                            D = D2;
                    }
                    if (TextB.Text == "" && D != "/")
                        TextB.Text = "0";
                        if ((D2 == "*" && D == "/") || (D2 == "/" && D == "*"))
                            D = D2;
                    dn2 = double.Parse(TextB.Text);
                    if (D == "-" || D == "*" || D == "+" || D == "/")//Выполнение арифметических операций
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
                        //Возращение значений
                        quantity = 0; onecomma = 0; g = 0; kol = 0; sqrtchisl = 0; shag = 0; doubleznak = 1;
                        znachenie = 0; value = 0; step = 0; razndeistv = 0; ymno = 0; delenn = 0;
                        entrance = false; slog = false;
                        D = ""; D2 = ""; N1 = ""; N3 = "";
                    }
                catch
                { TextB.Text = "Деление на ноль невозможно"; }
                }
                catch
                { TextB.Text = TextB.Text; }
            }
            else if (sender == ln) //Натуральный логорифм 
            {
                try
                {
                    znachenie = double.Parse(TextB.Text);
                    TextB.Clear();
                    TextB.Text += Math.Log(znachenie);
                }
                catch
                { TextB.Text = "Ошибка"; }
            }
            else if (sender == lg) //Десятичный логорифм
            {
                try { 
                znachenie = double.Parse(TextB.Text);
                TextB.Clear();
                TextB.Text += Math.Log10(znachenie);
                }
                catch
                { TextB.Text = "Ошибка"; }
            }
            else if (sender != comma) //Ввод на экран
            { TextB.Text += stroka;
                doubleznak++;
            }

        }
       
    }
} 
