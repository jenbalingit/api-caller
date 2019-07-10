using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PopAppShops.API.API
{
    public class Order
    {
        private readonly ServiceCaller caller;
        private readonly string url = string.Format("{0}/Order/", ServiceConfig.BaseUrl);
        public Order()
        {
            caller = new ServiceCaller();
        }

        public async Task<bool> SetAsPaid(string transactionID)
        {
            var raw = await caller.InvokeWithHeader(url + string.Format("?t={0}", transactionID), string.Empty, HttpMethod.Get);
            return JsonConvert.DeserializeObject<bool>(raw);
        }

        public async Task<string> UpdateStatus(DTO.DTOs.Order order)
        {
            return await caller.InvokeWithHeader(url, JsonConvert.SerializeObject(order), HttpMethod.Post);

        }

        public async Task<string> GetOrderByStatus(DTO.DTOs.OrdetStatus status, int skip, int take)
        {
            var raw = await caller.InvokeWithHeader(url + string.Format("?status={0}&skip={1}&take={2}", status, skip, take), string.Empty, HttpMethod.Get);
            return raw;
        }

        public async Task<string> GetMyOrder(int skip, int take)
        {
            var raw = await caller.InvokeWithHeader(url + string.Format("?skip={0}&take={1}", skip, take), string.Empty, HttpMethod.Get);
            return raw;
        }

        public async Task<string> GetDate(DTO.DTOs.OrdetStatus status)
        {
            string newurl = string.Format("{0}/GetOrders", ServiceConfig.BaseUrl);
            return await caller.InvokeWithHeader(newurl + string.Format("?status={0}", status), string.Empty, HttpMethod.Get);
        }
    }
}
