using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.DTO.DTOs
{
    public class WishList
    {
        public long WishListID { get; set; }
        public int Quantity { get; set; }
        public string ProductSKU { get; set; }
    }
}
