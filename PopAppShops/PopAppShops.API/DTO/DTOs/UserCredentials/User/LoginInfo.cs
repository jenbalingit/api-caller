using PopAppShop.Backend.DTOs.Response;
using System;

namespace PopAppShop.Backend.DTOs.User
{
    public class LoginInfo : ResponseCallback
    {
        //public string Token { get; set; }
        //public long UserId { get; set; }
        //public string Name { get; set; }
        //public bool IsSuccess { get; set; }
        //public string MerchantId { get; set; }
        //public bool IsAdmin { get; set; }
        
        public string Token { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public bool IsFacebook { get; set; }
        public bool IsSuccess { get; set; }
        public long MerchantId { get; set; }
        public bool IsAdmin { get; set; }
    
        
    }
}
