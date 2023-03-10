using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using WriteErase.pages;

namespace WriteErase
{
    /// <summary>
    /// Логика взаимодействия для WindowCaptcha.xaml
    /// </summary>
    public partial class WindowCaptcha : Window
    {
        string str = String.Empty;
        public WindowCaptcha()
        {
            InitializeComponent();
            //Random random = new Random();
            //string sym = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890";
            //for (int i = 0; i < 4; i++)
            //{
            //     str += sym[random.Next(sym.Length)];

            //    int margin = 20;
            //    TextBlock txt = new TextBlock()
            //    {
            //        Text = str[i].ToString(),
            //        FontSize = 18,
            //        FontFamily = new FontFamily("Calibri"),
            //        Margin = new Thickness(10),
            //    };
            //    CCaptcha.Children.Add(txt);

            //    TextBlock txt1 = new TextBlock()
            //    {
            //        Text = str[i].ToString(),
            //        FontSize = 18,
            //        FontFamily = new FontFamily("Calibri"),
            //        Margin = new Thickness(10)
            //    };
            //    CCaptcha.Children.Add(txt1);

            //    TextBlock txt2 = new TextBlock()
            //    {
            //        Text = str[i].ToString(),
            //        FontSize = 18,
            //        FontFamily = new FontFamily("Calibri"),
            //        Margin = new Thickness(10)
            //    };
            //    CCaptcha.Children.Add(txt2);

            //    TextBlock txt3 = new TextBlock()
            //    {
            //        Text = str[i].ToString(),
            //        FontSize = 18,
            //        TextDecorations = TextDecorations.Strikethrough,
            //        FontFamily = new FontFamily("Calibri"),
            //        Margin = new Thickness(10)
            //    };
            //    CCaptcha.Children.Add(txt3);              
            //}
            //for(int i = 0; i < 5; i++)
            //{
            //    Line l = new Line()
            //    {
            //        X1 = random.Next((int)CCaptcha.Width),
            //        Y1 = random.Next((int)CCaptcha.Height),
            //        X2 = random.Next((int)CCaptcha.Width),
            //        Y2 = random.Next((int)CCaptcha.Height),
            //    };
            //    CCaptcha.Children.Add(l);
            //}                        
            Random random = new Random();
            for (int n = 0; n < 5; n++)
            {
                Line l1 = new Line()
                {
                    X1 = random.Next(101),
                    Y1 = random.Next(51),
                    X2 = random.Next(101),
                    Y2 = random.Next(51)
                };
                CCaptcha.Children.Add(l1);
            }

            for (int n = 0; n < 4; n++)
            {
                int i = random.Next(2);
                switch (i)
                {
                    case 0:
                        str += (char)random.Next('a', 'z');
                        break;
                    case 1:
                        str += random.Next(10);
                        break;
                }
            }
            TextBlock tb = new TextBlock()
            {
                Text = str,
                TextDecorations = TextDecorations.Strikethrough,
                FontSize = 18,
                Margin = new Thickness(10)
            };
            CCaptcha.Children.Add(tb);
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCaptcha.Text.Length == 4)
            {
                if (tbCaptcha.Text == str)
                {
                    MessageBox.Show("Успешно!", "Подтверждение");
                    Close();
                    ClassFrame.frameL.Navigate(new ListOfTovar());
                }
                else
                {
                    MessageBox.Show("CAPTCHA введена неверно!", "Ошибка");
                    Close();
                    ClassFrame.frameL.Navigate(new PageAuto(1));                   
                }
            }
        }
    }
}
