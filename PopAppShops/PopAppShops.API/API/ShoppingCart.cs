using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.API
{
    public class ShoppingCart
    {
        string url = string.Format("{0}/ShoppingCart", ServiceConfig.BaseUrl);
        string urlWish = string.Format("{0}/WishList", ServiceConfig.BaseUrl);
        string cartCount = string.Format("{0}/CartCount", ServiceConfig.BaseUrl);
        ServiceCaller caller;
        public ShoppingCart()
        {
            caller = new ServiceCaller();
        }

        public async Task<string> GetCartCount()
        {
            return await caller.InvokeWithHeader(cartCount, string.Empty, HttpMethod.Get);
        }

        public async Task<string> GetShoppingCart()
        {
            try
            {
                string result = "";

                result = await caller.InvokeWithHeader(url, string.Empty, HttpMethod.Get);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }




        }

        public async Task<bool> AddToCart(DTO.ShoppingCartItem cart, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithHeader(url, JsonConvert.SerializeObject(cart), HttpMethod.Post);
                return JsonConvert.DeserializeObject<bool>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateCart(DTO.ShoppingCartItem cart, Action<ExceptionData> onError = null)
        {
            string result = "";
            try
            {
                result = await caller.InvokeWithHeader(url, JsonConvert.SerializeObject(cart), HttpMethod.Put);
                return JsonConvert.DeserializeObject<bool>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> Delete(long ID)
        {
            return await caller.InvokeWithHeader(url + string.Format("?shoppingCartID={0}", ID), string.Empty, HttpMethod.Delete);
        }


        public async Task<string> AddToWish(string SKU)
        {
            return await caller.InvokeWithHeader(urlWish + string.Format("?productSKU={0}", SKU), string.Empty, HttpMethod.Put);

        }

        public async Task<string> GetWish(int skip, int take)
        {
            return await caller.InvokeWithHeader(urlWish + string.Format("?skip={0}&take={1}", skip, take), string.Empty, HttpMethod.Get);
        }

        public async Task<string> MoveToCart(DTO.DTOs.WishList wish)
        {
            return await caller.InvokeWithHeader(urlWish, JsonConvert.SerializeObject(wish), HttpMethod.Post);
        }
    }
}
