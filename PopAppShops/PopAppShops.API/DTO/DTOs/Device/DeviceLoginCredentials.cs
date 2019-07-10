using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Device
{
    public class DeviceLoginCredentials : BaseDevice
    {
        // WILL GENERATE ON SPLASH SCREEN

        long _companyId;
        long _userId;

        public string ApplicationID { get; set; }

        public long CompanyID {
            get {
                return _companyId;
            }
            set {
                _companyId = 1;
            } }

        public long UserID
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = 1;
            }
        }
    }
}
