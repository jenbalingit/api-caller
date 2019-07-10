
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PopAppShop.Backend.DTOs.Device;
using Core.Cryptography;
using System.Net;

namespace PopAppShops.API
{
    public class ServiceCaller
    {
        Action<string, string, HttpMethod, bool, string, string, string> Logger;
        private readonly HttpClient client;
        public ServiceCaller(Action<string, string, HttpMethod, bool, string, string, string> Logger = null)
        {
            client = new HttpClient();
            this.Logger = Logger;
        }


        public ServiceCaller()
        {
            client = new HttpClient();
        }
        public async Task<string> Invoke(string url, string parameter, HttpMethod actionMethod, bool hasHeader = true)
        {
            string response = string.Empty;
            string DeviceHeader = "";
            string AuthToken = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (HttpRequestMessage request = new HttpRequestMessage(actionMethod, new Uri(url)))
            using (HttpClient _client = new HttpClient())

            {



                if (request.Method != HttpMethod.Get)
                    request.Content = new StringContent(parameter, Encoding.UTF8, "application/json");

                if (hasHeader)
                {
                    DeviceHeader = CreateHeader();
                    AuthToken = GetAuthTicket();
                    request.Headers.Add("Device", DeviceHeader);
                    request.Headers.Add("Authentication-Token", AuthToken);
                }

                var task = await _client.SendAsync(request);

                var result = task.Content.ReadAsStringAsync();
                response = result.Result;

            }

            return response;
        }

        public Task<string> InvokeWithHeader(string url, string parameter, HttpMethod actionMethod)
        {
            return Invoke(url, parameter, actionMethod, true);
        }

        public Task<string> InvokeWithoutHeader(string url, string parameter, HttpMethod actionMethod)
        {
            return Invoke(url, parameter, actionMethod, false);
        }

        public string CreateHeader()
        {
            ClientToken Token = new TextFileManager<ClientToken>(@"c:\popappsdata\device.txt").RetreiveFiles();

            string now = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            string _hash = Hashbrowns.Hash(now, Token.Salt);
            string session = string.Format(
                "{{\"s\":\"{0}\",\"n\":\"{1}\",\"t\":\"{2}\"}}",
                Token.SessionID, _hash, now
            );
            return session;
        }

        public string GetAuthTicket()
        {
            return new TextFileManager<string>(@"c:\popappsdata\authticket.txt").RetreiveFiles();
        }
    }
}
