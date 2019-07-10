using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Product
{
    public class TopDiscount
    {
        public long ID { get; set; }
        public string ProductSKU { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public long ProductID { get; set; }
    }
}
