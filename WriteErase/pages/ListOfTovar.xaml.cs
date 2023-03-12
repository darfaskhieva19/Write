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

namespace WriteErase.pages
{
    /// <summary>
    /// Логика взаимодействия для ListOfTovar.xaml
    /// </summary>
    public partial class ListOfTovar : Page
    {
        List<Product> listFilter;
        User user;
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
            if(user.Role.RoleName == "администратор" || user.Role.RoleName == "менеджер")
            {
                btnZakaz.Visibility = Visibility.Visible;
            }
            Filter();
        }
        public void Filter()
        {
            listFilter = DataBase.Base.Product.ToList();

            //сортировка
            switch (cbSort.SelectedIndex)
            {
                case 1:
                    //listFilter = listFilter.OrderBy(z=>z.NewCost).ToList();
                    listFilter.Sort((x,y)=>x.ProductCost.CompareTo(y.ProductCost));
                    break;
                case 2:
                    //listFilter = listFilter.OrderByDescending(z => z.NewCost).ToList();
                    listFilter.Sort((x, y) => x.ProductCost.CompareTo(y.ProductCost));
                    listFilter.Reverse();
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

        private void btnZakaz_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new pages.ListOfOrder());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            windows.WindowOrder order = new windows.WindowOrder();
            order.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new pages.PageAuto());
        }

        private void btnDelete_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string index = btn.Uid;
                Product product = DataBase.Base.Product.FirstOrDefault(z=>z.ProductArticleNumber == index);
                List<OrderProduct> orderProducts = DataBase.Base.OrderProduct.Where(x => x.ProductArticleNumber == index).ToList();
                if (orderProducts.Count == 0)
                {
                    foreach(OrderProduct OProducts in orderProducts)
                    {
                        DataBase.Base.OrderProduct.Remove(OProducts);
                    }
                    DataBase.Base.Product.Remove(product);
                    DataBase.Base.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Товар невозможно удалить, потому что он есть в заказе!");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так..");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(user.Role.RoleName == "Менеджер" || user.Role.RoleName == "Администратор")
            {
               // btnDelete.Visibility = Visibility.Visible;
            }
            else
            {
               // btnDelete.Visibility = Visibility.Collapsed;
            }
        }
    }
}
