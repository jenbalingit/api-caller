using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.API
{
    public class Address
    {

        private readonly ServiceCaller caller;
        private readonly string url = string.Format("{0}/Address/", ServiceConfig.BaseUrl);
        public Address()
        {
            caller = new ServiceCaller();
        }

        public async Task<long> Add(DTO.Address add)
        {
            var raw = await caller.InvokeWithHeader(url, JsonConvert.SerializeObject(add), HttpMethod.Put);

            return JsonConvert.DeserializeObject<long>(raw);


        }
    }
}
