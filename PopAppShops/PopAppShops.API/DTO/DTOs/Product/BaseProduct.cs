using PopAppShop.Backend.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Product
{
    public class PropertyValues
    {
        public string SKU { get; set; }
        public long LookUpId { get; set; }
        public string PropertyName { get; set; }
        public long AdditionalPropertyID { get; set; }
        public long OrderBy { get; set; }
    }

    public class BaseProduct : ResponseCallback
    {
        public string Currency { get; set; }
        public long CompanyID { get; set; }
        public string Name { get; set; }
        public string CategoryID { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public long? ImageID { get; set; }
        public string ProductID { get; set; }
        public List<PropertyValues> Properties { get; set; }
    }

    public class ProductSearch
    {
        public ProductSearch()
        {

        }

        public string Currency { get; set; }

        public long CompanyID { get; set; }

        public string Name { get; set; }

        public string CategoryID { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public long? ImageID { get; set; }

        public string ProductID { get; set; }

        public string SKU { get; set; }

    }
}
