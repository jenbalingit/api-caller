using PopAppShop.Backend.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Home
{
    public class Home : ResponseCallback
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
