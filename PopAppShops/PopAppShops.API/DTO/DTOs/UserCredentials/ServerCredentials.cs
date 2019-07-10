using Newtonsoft.Json;
using PopAppShop.Backend.DTOs.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.UserCredentials
{
    public class ServerCredentials
    {
        public ServerCredentials()
        {
            
        }

        public ServerCredentials(ClientToken clientToken, string token)
        {
            AuthTicket = clientToken.AuthTicket;
            SessionID = clientToken.SessionID;
            Salt = clientToken.Salt;
            Token = token;
        }

        public string AuthTicket { get; set; }
        public string SessionID { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
    }
}
