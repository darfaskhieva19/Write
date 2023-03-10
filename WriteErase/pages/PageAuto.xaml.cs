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
using System.Windows.Threading;

namespace WriteErase.pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        int time = 10;
        string str = String.Empty;
        int k;
        public PageAuto()
        {
            InitializeComponent();  
           
        }
        public PageAuto(int k)
        {
            InitializeComponent();
            switch (k)
            {
                case 0:
                    btAuto.IsEnabled = true;
                    tbLogin.Focus();
                    spCode.Visibility = Visibility.Collapsed;
                    break;
                case 1:                   
                    btAuto.IsEnabled = false;
                    tbLogin.Focus();
                    timer.Interval = new TimeSpan(0, 0, 1);
                    timer.Tick += new EventHandler(Timer_Tick);
                    timer.Start();
                    spCode.Visibility = Visibility.Visible;
                    break;
            }
           //CAPTCHA();           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            tbTime.Text = "Вы сможете зайти через " + time + " секунд";
            if (time < 0)
            {
                timer.Stop();
                btAuto.IsEnabled = true;
                tbTime.Visibility = Visibility.Collapsed;
            }
        }

        private void tbAuto_Click(object sender, RoutedEventArgs e)
        {     
            User user = DataBase.Base.User.FirstOrDefault(z => z.UserLogin == tbLogin.Text && z.UserPassword == tbPassword.Password);
            if (user == null)
            {
                MessageBox.Show("Вы ввели данные неверно! Повторите вход!");
                CAPTCHA();
            }
            else
            {
                ClassFrame.frameL.Navigate(new pages.ListOfTovar(user));                
            }
        }

        public void CAPTCHA()
        {
            WindowCaptcha captcha = new WindowCaptcha();
            captcha.ShowDialog();
        }

        private void tbGuest_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new pages.ListOfTovar());
        }             
    }
}
