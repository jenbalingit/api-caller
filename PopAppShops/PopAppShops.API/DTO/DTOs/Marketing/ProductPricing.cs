using Core.Cryptography;
using Grabhut.Data.EFBase;

namespace PopAppsShops.Api.DTOs.Marketing
{
    public class ProductPricing : BaseDTO
    {
        public ProductPricing()
        {

        }

        public long CompanyID { get; set; }
    
        public string ProductSKU { get; set; }

        public double Discount { get; set; }

        public double Price { get; set; }

        string _productID;
        public string ProductID
        {
            get { return _productID; }
            set { _productID = Encryption.Encrypt(value); }
        }
    }
}