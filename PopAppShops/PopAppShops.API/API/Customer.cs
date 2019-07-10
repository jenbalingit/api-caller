using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs = PopAppShop.Backend.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using PopAppShop.Backend.DTOs.User;

namespace PopAppShops.API.API
{
    public class Customer
    {
        string url = string.Format("{0}/merchant", ServiceConfig.BaseUrl);
        ServiceCaller caller;
        Action<ExceptionData> onError;
        public Customer(Action<ExceptionData> onError, Action<string, string, HttpMethod, bool, string, string, string> Logger = null)
        {
            this.onError = onError;
            caller = new ServiceCaller(Logger);
        }

        public async Task<bool> Register(DTO.UserInfo info, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithoutHeader(url, JsonConvert.SerializeObject(info), HttpMethod.Put);
                return JsonConvert.DeserializeObject<bool>(result);
            }
            catch
            {
                var data = JsonConvert.DeserializeObject<ExceptionData>(result);
                if (onError == null)
                    this.onError(data);
                else
                    onError(data);

                return false;
            }
        }
        
        public async Task<LoginInfo> Login(UserCredentials info,Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithoutHeader(url, JsonConvert.SerializeObject(info), HttpMethod.Post);
                return JsonConvert.DeserializeObject<LoginInfo>(result);
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

        public async Task<bool> RegisterFacebook(string accessToken, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithoutHeader("http://localhost:48999/api/FacebookSignUp?accessToken=" + accessToken, string.Empty, HttpMethod.Get);
                return JsonConvert.DeserializeObject<bool>(result);
            }
            catch
            {
                var data = JsonConvert.DeserializeObject<ExceptionData>(result);
                if (onError == null)
                    this.onError(data);
                else
                    onError(data);

                return false;
            }
        }

        public async Task<LoginInfo> LoginFacebook(string accessToken, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithoutHeader("http://localhost:8080/api/FacebookAuth?accessToken=" + string.Format("{0}&companyID=1", accessToken), string.Empty, HttpMethod.Get);
                return JsonConvert.DeserializeObject<LoginInfo>(result);
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

        public async Task<bool> ForgotPassword(string emailAddres, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithoutHeader(string.Format("{0}ForgotPassword?emailAddress={1}",ServiceConfig.BaseUrl,emailAddres), string.Empty, HttpMethod.Get);
                return JsonConvert.DeserializeObject<bool>(result);
            }
            catch
            {
                var data = JsonConvert.DeserializeObject<ExceptionData>(result);
                if (onError == null)
                    this.onError(data);
                else
                    onError(data);

                return false;
            }
        }
    }
}
