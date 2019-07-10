using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Device
{
    public class UserDeviceLogin : BaseDevice
    {
        public long CompanyID { get; set; }
        public long UserId { get; set; }
        public string ApplicationID { get; set; }
        public string Token { get; set; }
    }
}
