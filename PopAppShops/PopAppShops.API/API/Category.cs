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
    public class Category
    {
        string url = string.Format("{0}/category", ServiceConfig.BaseUrl);
        ServiceCaller caller;
        Action<ExceptionData> onError;
        public Category()
        {
            caller = new ServiceCaller();
        }
        public Category(Action<ExceptionData> onError, Action<string, string, HttpMethod, bool, string, string, string> Logger = null)
        {
            this.onError = onError;
            caller = new ServiceCaller(Logger);
        }

        public async Task<List<DTOs.Category.Category>> GetCategories(Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithHeader(url, string.Empty, HttpMethod.Get);
                return JsonConvert.DeserializeObject<List<DTOs.Category.Category>>(result);
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

        public async Task<string> GetCate()
        {
            var result = await caller.InvokeWithHeader(string.Format("{0}/Categories", ServiceConfig.BaseUrl), string.Empty, HttpMethod.Get);
            return result;
        }

        public async Task<List<DTOs.Category.Category>> GetSubCategories(long parentCategory, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithHeader(url + string.Format("?parentCategoryID={0}", parentCategory), string.Empty, HttpMethod.Get);
                return JsonConvert.DeserializeObject<List<DTOs.Category.Category>>(result);
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
