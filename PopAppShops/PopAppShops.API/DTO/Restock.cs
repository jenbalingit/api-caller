using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.DTO
{
    public class Restock
    {
        public Restock()
        {

        }
        public Restock(InventoryUniqueId inventoryUnique)
        {
            if (string.IsNullOrEmpty(inventoryUnique.ProductSKU))
            { Sku = inventoryUnique.Sku; }
            else if (string.IsNullOrEmpty(inventoryUnique.Sku))
            { Sku = inventoryUnique.ProductSKU; }
            
            SerialNumber = inventoryUnique.SerialNumber;
            Status = inventoryUnique.Status;
            Quantity = inventoryUnique.Quantity;

        }

        public string Sku { get; set; }
        public int Quantity { get; set; }
        public string SerialNumber { get; set; }
        public long ProductId { get; set; }
        public bool IsOut { get; set; }

        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public string TransactionNumber { get; set; }
        public SerialNumberStatus Status { get; set; }
        public string InvoiceNumber { get; set; }
    }

    public enum SerialNumberStatus
    {
        In,
        Out,
        Sell
    }

    public class Transactions
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public SerialNumberStatus Action { get; set; }
        
        public InventoryUniqueId Item { get; set; }
    }
}
