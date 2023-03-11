using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WriteErase
{
    public partial class Order
    {
        public string NumberOrder
        {
            get
            {
                return "Номер заказа: " + OrderID;
            }
        }
        public string OrderS
        {
            get
            {
                string str = "Состав заказа: ";
                List<OrderProduct> products = DataBase.Base.OrderProduct.Where(z=>z.OrderID == OrderID).ToList();   
                foreach(OrderProduct prod in products)
                {
                    Product product = DataBase.Base.Product.FirstOrDefault(z=>z.ProductArticleNumber==prod.ProductArticleNumber);
                    str += product.TitleProduct.TitleProduct1 + ", ";
                }
                return str.Substring(0, str.Length - 2);
            }
        }
        //public double Summ //общая сумма заказа
        //{
        //    get
        //    {
        //        List<>
        //    }
        //}
        public string FIOClient //вывод ФИО клиента
        {
            get
            {
                if(OrderClient != null)
                {
                    return "Клиент: " + OrderClient;
                }
                else
                {
                    return null;
                }
            }
        }
        //public SolidColorBrush Color
        //{
        //    get
        //    {
        //        if ()
        //        {
        //            SolidColorBrush solid = new SolidColorBrush(Color.FromRgb(127, 255, 0));
        //            return solid;
        //        }
        //        else
        //        {
        //            return Brushes.White;
        //        }
        //    }
        //}
    }
}
