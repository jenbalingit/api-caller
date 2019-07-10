using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace PopAppShops.API.API
{
    public class Favorites
    {
        string url = string.Format("{0}/favorites", ServiceConfig.BaseUrl);
        ServiceCaller caller;
        public Favorites()
        {
            caller = new ServiceCaller();
        }

        public async Task<string> Get(int skip, int take)
        {
            return await caller.InvokeWithHeader(url + string.Format("?skip={0}&take={1}", skip, take), string.Empty, HttpMethod.Get);
        }

        public async Task<string> Insert(DTO.DTOs.Favorite fav)
        {
            return await caller.InvokeWithHeader(url, JsonConvert.SerializeObject(fav), HttpMethod.Put);
        }

        public async Task<string> Delete(long ID)
        {
            return await caller.InvokeWithHeader(url + string.Format("?ID={0}", ID), string.Empty, HttpMethod.Delete);
        }
    }
}
