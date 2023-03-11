using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WriteErase
{
    public partial class Product
    {
        public string Name //вывод наименования
        {
            get
            {
                return TitleProduct.TitleProduct1;
            }
        }
        public string Desc //вывод описания
        {
            get
            {
                return ProductDescription;
            }
        }
        public string Manufact //вывод производителя
        {
            get
            {
                return "Производитель: " + Manufacturer.ProductManufacturer;
            }
        }
        public SolidColorBrush ColorDiscount //товар со скидкой
        {
            get
            {
                if (ProductDiscountMax > 15)
                {
                    SolidColorBrush solid = new SolidColorBrush(Color.FromRgb(127, 255, 0));
                    return solid;
                }
                else
                {
                    return Brushes.White;
                }
            }
        }
        public string Disc //вывод скидки
        {
            get
            {
                return "Скидка " + ProductDiscountAmount + " %";
            }
        }
        public string Price //вывод цены
        {
            get
            {
                return string.Format("{0:N2}", ProductCost) + " руб.";
            }
        }
        public string NewCost //вывод цены со скидкой
        {
            get
            {
                if (ProductDiscountAmount > 0)
                {
                   return (double)(Convert.ToDouble(ProductCost) - (Convert.ToDouble(ProductCost) * ProductDiscountAmount / 100)) + " руб.";
                }
                else
                {
                    return "";
                }
            }
        }
        public string Photo
        {
            get
            {
                if (ProductPhoto != null)
                {
                    return "\\picture\\" + ProductPhoto;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
