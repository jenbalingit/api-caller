using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PopAppsShops.Api.DTOs.Marketing;
using Newtonsoft.Json;

namespace PopAppShops.API.API
{
    public class Marketing
    {
        string url = string.Format("{0}/FeaturedProduct", ServiceConfig.BaseUrl);

        ServiceCaller caller;
        Action<ExceptionData> onError;
        public Marketing()
        {
            caller = new ServiceCaller();
        }

        public async Task<string> GetFeatureProducts()
        {
            return await caller.InvokeWithHeader(url, string.Empty, HttpMethod.Get);

        }

        public async Task<string> GetTopDiscount()
        {
            url = string.Format("{0}/Marketing", ServiceConfig.BaseUrl);
            return await caller.InvokeWithHeader(url + "?skip=0&take=100", string.Empty, HttpMethod.Get);

        }
    }

    public class Reward
    {
        string url = string.Format("{0}/Reward", ServiceConfig.BaseUrl);

        ServiceCaller caller;
        Action<ExceptionData> onError;
        public Reward()
        {
            caller = new ServiceCaller();
        }

        public async Task<string> GetRewardByBranch()
        {
            url = string.Format("{0}/Reward", ServiceConfig.BaseUrl);
            return await caller.InvokeWithHeader(url, string.Empty, HttpMethod.Get);

        }

        public async Task<string> GetRedeemItem(int points)
        {
            url = string.Format("{0}/Reward", ServiceConfig.BaseUrl);
            return await caller.InvokeWithHeader(url + $"?points={points}", string.Empty, HttpMethod.Get);

        }
    }
}
