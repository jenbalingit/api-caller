using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Device
{
    public abstract class BaseDevice 
    {
        public string Code { get; set; } // COMBINATION OF DEVICE KEY AND DESCRIPTION

        public string Description { get; set; } // ANDROID/OS VERSION

        public string DeviceKey { get; set; } //IMEI

        public string ApplicationID { get; set; }
    }
}
