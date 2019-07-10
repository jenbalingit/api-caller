using PopAppShop.Backend.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Device
{
    
    public class ClientToken : ResponseCallback
    {
        public string Salt { get; set; }
        public string SessionID { get; set; }
        public string AuthTicket { get; set; }
    }
}
