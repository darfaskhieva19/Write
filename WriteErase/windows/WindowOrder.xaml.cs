﻿using System;
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

namespace WriteErase.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        public WindowOrder()
        {
            InitializeComponent();

        }
        public WindowOrder(User user)
        {
            InitializeComponent();
            if(user != null)
            {
                tbFIO.Text = " " + user.UserSurname + " " + user.UserName + " " + user.UserPatronymic;
            }
        }
    }
}
