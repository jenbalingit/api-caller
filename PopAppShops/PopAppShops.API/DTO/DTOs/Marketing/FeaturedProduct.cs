using Core.Cryptography;
using Grabhut.Data.EFBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopAppsShops.Api.DTOs.Marketing
{
    public class FeaturedProduct : BaseDTO
    {
        public FeaturedProduct()
        {

        }
    
        public long CompanyID { get; set; }
        public string ProductSKU { get; set; }
        string _productID;
        public string ProductID
        {
            get { return _productID; }
            set { _productID = Encryption.Encrypt(value); }
        }
    }
}