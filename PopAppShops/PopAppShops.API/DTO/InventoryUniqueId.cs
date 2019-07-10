using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.DTO
{
    public class InventoryUniqueId
    {
        public InventoryUniqueId()
        {

        }
        public InventoryUniqueId(Restock restock)
        {
            ProductId = 3869;
            SerialNumber = restock.SerialNumber;
            Sku = restock.Sku;
            Quantity = restock.Quantity;
        }


        public long ID { get; set; }

        public SerialNumberStatus Status { get; set; }

        public long InventoryLogId { get; set; }

        public string ProductSKU { get; set; }

        public string SerialNumber { get; set; }

        public bool Sold { get; set; }

        public bool IsOut { get; set; }

        public long ProductId { get; set; }
        public long BranchId { get; set; }

        public long CompanyId { get; set; }
        public string InvoiceNumber { get; set; }
        public string TransferId { get; set; }

        public int Quantity { get; set; }

        public string Sku { get; set; }
    }
}
