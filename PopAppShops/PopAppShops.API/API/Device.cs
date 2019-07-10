using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs = PopAppShop.Backend.DTOs;
using Newtonsoft.Json;
using System.Net.Http;

namespace PopAppShops.API.API
{
    public class Device
    {
        string url = string.Format("{0}/device", ServiceConfig.BaseUrl);
        ServiceCaller caller;
        Action<ExceptionData> onError;
        public Device(Action<ExceptionData> onError, Action<string, string, HttpMethod, bool, string, string, string> Logger = null)
        {
            this.onError = onError;
            caller = new ServiceCaller(Logger);
        }

        public async Task<bool> DeviceRegister(DTOs.Device.DeviceLoginCredentials device, Action<ExceptionData> onError = null)
        {
            string result = "";

            result = await caller.InvokeWithoutHeader(url, JsonConvert.SerializeObject(device), HttpMethod.Put);
            return JsonConvert.DeserializeObject<bool>(result);

        }

        public async Task<DTOs.Device.ClientToken> DeviceLogin(DTOs.Device.DeviceLoginCredentials device, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                url = string.Format("{0}/DeviceLogin", ServiceConfig.BaseUrl);
                result = await caller.InvokeWithoutHeader(url, JsonConvert.SerializeObject(device), HttpMethod.Post);
                return JsonConvert.DeserializeObject<DTOs.Device.ClientToken>(result);
            }
            catch
            {
                var data = JsonConvert.DeserializeObject<ExceptionData>(result);
                if (onError == null)
                    this.onError(data);
                else
                    onError(data);


                return null;
            }
        }
    }
}
