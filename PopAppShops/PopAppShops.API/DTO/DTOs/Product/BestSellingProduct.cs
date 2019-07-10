using PopAppShop.Backend.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Product
{
    public class BestSellingProduct
    {
        public string ProductSKU { get; set; }
        public string ProductName { get; set; }
        public long ProductID { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

}
