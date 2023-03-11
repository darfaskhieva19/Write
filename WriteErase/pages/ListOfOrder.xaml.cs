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
    /// Логика взаимодействия для ListOfOrder.xaml
    /// </summary>
    public partial class ListOfOrder : Page
    {
        public ListOfOrder()
        {
            InitializeComponent();
            lvOrder.ItemsSource = DataBase.Base.Order.ToList();
            cbFilter.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new pages.ListOfTovar());
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
