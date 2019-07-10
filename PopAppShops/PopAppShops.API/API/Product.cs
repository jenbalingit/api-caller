using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTOs = PopAppShop.Backend.DTOs;

namespace PopAppShops.API.API
{
    public class Product
    {
        string url = string.Format("{0}/product", ServiceConfig.BaseUrl);
        readonly ServiceCaller caller;

        public Product()
        {

            caller = new ServiceCaller();
        }
        public async Task<string> Search(string query)
        {
            url = string.Format("{0}/productsearch?q={1}&pageNumber=1", ServiceConfig.BaseUrl, query);
            var result = await caller.InvokeWithHeader(url, string.Empty, HttpMethod.Get);
            return result;

        }

        public async Task<string> LoadByCategory(long categoryID, int skip, int take)
        {

            url = string.Format("{0}/products?categoryID={1}&skip={2}&take={3}", ServiceConfig.BaseUrl, categoryID, skip, take);
            var result = await caller.InvokeWithHeader(url, string.Empty, HttpMethod.Get);
            return result;
        }

        public async Task<string> GetProductById(string productId)
        {

            url = $"{ServiceConfig.BaseUrl}/products?productsID={productId}";
            var result = await caller.InvokeWithHeader(url, string.Empty, HttpMethod.Get);
            return result;
        }
    }
}
