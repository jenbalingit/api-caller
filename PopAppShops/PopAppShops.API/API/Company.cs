using Newtonsoft.Json;
using PopAppShop.Backend.DTOs.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.API
{
    public class Company
    {
        private string urlCheckoutLogin = string.Format("{0}/CompanyAddress", ServiceConfig.BaseUrl);
        ServiceCaller caller;
        public Company()
        {
            caller = new ServiceCaller();
        }

        public async Task<string> GetMeetUpAddress()
        {
            return await caller.InvokeWithHeader(urlCheckoutLogin, string.Empty, HttpMethod.Get);
        }

        public async Task<string> GetByEmail()
        {
            urlCheckoutLogin = string.Format("{0}/Merchant", ServiceConfig.BaseUrl);
            return await caller.InvokeWithHeader(urlCheckoutLogin, string.Empty, HttpMethod.Get);
        }

        public async Task<string> LoginDevice(UserDeviceLogin cred)
        {
            urlCheckoutLogin = string.Format("{0}/MerchantDevice", ServiceConfig.BaseUrl);
            return await caller.InvokeWithHeader(urlCheckoutLogin, JsonConvert.SerializeObject(cred), HttpMethod.Post);
        }
    }
}
