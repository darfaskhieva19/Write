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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WriteErase.pages
{
    /// <summary>
    /// Логика взаимодействия для ListOfTovar.xaml
    /// </summary>
    public partial class ListOfTovar : Page
    {
        List<Product> listFilter;
        public ListOfTovar()
        {
            InitializeComponent();
            ListT.ItemsSource = DataBase.Base.Product.ToList();
            cbSort.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;

            Filter();
        }
        public ListOfTovar(User user)
        {
            InitializeComponent();
            ListT.ItemsSource = DataBase.Base.Product.ToList();
            cbSort.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;
            tbFIO.Text = " " + user.UserSurname + " " + user.UserName + " " + user.UserPatronymic;
            Filter();
        }
        public void Filter()
        {
            listFilter = DataBase.Base.Product.ToList();

            //сортировка
            switch (cbSort.SelectedIndex)
            {
                case 1:
                    listFilter = listFilter.OrderByDescending(z=>z.NewCost).ToList();                      
                    break;
                case 2:
                    listFilter = listFilter.OrderBy(z => z.NewCost).ToList();
                    break;
            }

            //фильтр
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    listFilter = listFilter.Where(x => x.ProductDiscountAmount > 0 && x.ProductDiscountAmount < 9.99).ToList();
                    break;
                case 2:
                    listFilter = listFilter.Where(x => x.ProductDiscountAmount > 10 && x.ProductDiscountAmount < 14.99).ToList();
                    break;
                case 3:
                    listFilter = listFilter.Where(x => x.ProductDiscountAmount > 15).ToList();
                    break;
            }

            //поиск
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                listFilter = listFilter.Where(x => x.TitleProduct.TitleProduct1.ToLower().Contains(tbSearch.Text.ToLower())).ToList(); //поиск по наименованию
            }

            tbCountZap.Text = listFilter.Count.ToString() + " из " + DataBase.Base.Product.ToList().Count.ToString(); //количество записей

            ListT.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Системное сообщение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

            }
        }
    }
}