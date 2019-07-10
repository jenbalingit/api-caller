using Grabhut.Data.EFBase;
using System;

namespace PopAppsShops.Api.DTOs.Marketing
{
    public class InventoryLogs : BaseDTO
    {
        public InventoryLogs()
        {

        }
        public long CompanyID { get; internal set; }



        public string ProductSKU { get; set; }

        public string ProductName { get; set; }

        public long ProductID { get; set; }

        public int Count { get; set; }

        public int Quantity { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}