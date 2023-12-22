using Sales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sales.Domain.Entities
{
    public class SalesItems : EntityBase
    {
        public int Unit { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        private decimal totalPrice = 0;
        public decimal TotalPrice
        {
            get
            {
                totalPrice = Price * Unit;

                return totalPrice;
            }
            set { totalPrice = value; }
        }
    }
}
