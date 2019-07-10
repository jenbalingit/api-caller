using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.DTO
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
    public class ShoppingCartItem
    {
        public long ID { get; set; }

        public int Quantity { get; set; }

        public string ProductSKU { get; set; }

    }
}
