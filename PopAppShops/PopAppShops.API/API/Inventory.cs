using Newtonsoft.Json;
using PopAppShops.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.API
{
    public class Inventory
    {
        string url = string.Format("{0}/Inventory", ServiceConfig.BaseUrl);
        readonly ServiceCaller caller;

        public Inventory()
        {

            caller = new ServiceCaller();
        }

        public async Task<string> Restock(Restock restock)
        {

            var result = await caller.InvokeWithHeader(url, JsonConvert.SerializeObject(restock), HttpMethod.Put);
            return result;

        }



        public async Task<string> BatchRestockInventory(List<Restock> restock)
        {

            var result = await caller.InvokeWithHeader($"{ServiceConfig.BaseUrl}/BatchRestockInventory", JsonConvert.SerializeObject(restock), HttpMethod.Put);
            return result;

        }

        public async Task<string> UpdateUnique(Restock restock)
        {

            var result = await caller.InvokeWithHeader(url, JsonConvert.SerializeObject(restock), HttpMethod.Post);
            return result;

        }

        public async Task<KeyValuePair<string, string>> GetBranchInventory(string sku)
        {
            var result = await caller.InvokeWithHeader($"{ServiceConfig.BaseUrl}/Serial?sku={sku}", string.Empty, HttpMethod.Get);
            return new KeyValuePair<string, string>(sku, result);

        }
    }
}
