using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.API
{
    public class Checkout
    {
        string urlCheckoutLogin = string.Format("{0}/StandardCheckoutLogin", ServiceConfig.BaseUrl);
        string urlSocialCheckoutLogin = string.Format("{0}/SocialCheckoutLogin", ServiceConfig.BaseUrl);
        string urlCheckout = string.Format("{0}/Checkout", ServiceConfig.BaseUrl);

        ServiceCaller caller;
        public Checkout()
        {
            caller = new ServiceCaller();
        }


        public async Task<string> CheckoutLogin(string password)
        {
           
            var raw = await caller.InvokeWithHeader(urlCheckoutLogin + string.Format("?password={0}", password), string.Empty, HttpMethod.Get);
            return JsonConvert.DeserializeObject<string>(raw);
        }

        public async Task<string> SocialCheckoutLogin(string accessToken)
        {
            var raw = await caller.InvokeWithHeader(urlSocialCheckoutLogin + string.Format("?accessToken={0}", accessToken), string.Empty, HttpMethod.Get);
            return JsonConvert.DeserializeObject<string>(raw);
        }

        public async Task<DTO.DTOs.CheckoutResponse> CheckoutOrder(DTO.DTOs.Checkout c)
        {
           // var s = '{CheckoutSessionID":"1487737261","IsCredicard":false,"ShippingMethod":0,"AddressID":11,"ShippingDate":null,"SuccessUrl":"https://popweb.basecamptech.ph/CheckOut/Result","CancelUrl":"https://popweb.basecamptech.ph/CheckOut/Result","FailUrl":"https://popweb.basecamptech.ph/CheckOut/Result","MeetUpDetailID":0,"MeetUpDate":"0001-01-01T00:00:00"}';
            var raw = await caller.InvokeWithHeader(urlCheckout, JsonConvert.SerializeObject(c), HttpMethod.Post);
            return JsonConvert.DeserializeObject<DTO.DTOs.CheckoutResponse>(raw);
        }

        public async Task<string> ExpressCheckoutOrder(DTO.DTOs.Checkout c)
        {
            // var s = '{CheckoutSessionID":"1487737261","IsCredicard":false,"ShippingMethod":0,"AddressID":11,"ShippingDate":null,"SuccessUrl":"https://popweb.basecamptech.ph/CheckOut/Result","CancelUrl":"https://popweb.basecamptech.ph/CheckOut/Result","FailUrl":"https://popweb.basecamptech.ph/CheckOut/Result","MeetUpDetailID":0,"MeetUpDate":"0001-01-01T00:00:00"}';
            var raw = await caller.InvokeWithHeader(urlCheckout, JsonConvert.SerializeObject(c), HttpMethod.Put);
            return raw;
        }

    }
}
