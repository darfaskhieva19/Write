using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteErase
{
    public partial class Order
    {
        public string NumberOrder
        {
            get
            {
                return "Номер заказа: " + " ";
            }
        }
        public string SostavOrder
        {
            get
            {
                return "";
            }
        }
        public string Date
        {
            get
            {
                return "Дата заказа: " + OrderDate;
            }
        }
        public string FIOClient //вывод ФИО клиента
        {
            get
            {
                return OrderClient;
            }
        }
    }
}
