using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShops.API.DTO.DTOs
{
    public enum OrdetStatus
    {
        New = 1,
        Inprogress = 2,
        Schedule = 3,
        Completed = 4,
        Cancel = 5
    }

    public class Order
    {
        public long ID { get; set; }
        public decimal Amount { get; set; }

        public long UserID { get; set; }

        public long? DeliveryAddress { get; set; }

        public string SalesInvoiceNumber { get; set; }

        public DateTime? ShippingDate { get; set; }

        public string ShippingMethod { get; set; }

        public string TransactionID { get; set; }

        public bool IsPaid { get; set; }

        public OrdetStatus Status { get; set; }
    }
}
