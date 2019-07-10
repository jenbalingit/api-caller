using System;

namespace PopAppShops.API.DTO.DTOs
{
    public enum PaymentMethod
    {
        Cash = 0,
        CreditCard = 1,
        None = 2
    }
    public class Checkout
    {
        public string CheckoutSessionID { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public PaymentMethod IsCredicard { get; set; }
        //Shipping Details
        public string ShippingMethod { get; set; }
        public long AddressID { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
        public string FailUrl { get; set; }
        public long MeetUpDetailID { get; set; }
        public DateTime? MeetUpDate { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public string SerialNumber { get; set; }
        public int CustomerId { get; set; }
        public UserType UserType { get; set; }
        public long DiscountId { get; set; }
        public NewWarranty Warranty { get; set; }
    }

    public class NewWarranty
    {

        public string InvoiceNumber { get; set; }

        public string warranty_class { get; set; }

        public string plate_number { get; set; }

        public DateTime date_expire { get; set; }

        public DateTime date_purchase { get; set; }

        public string sku { get; set; }

        public string serial { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string mobile_number { get; set; }



    }
    public enum UserType
    {
        Customer = 0,
        CompanyUser = 1
    }

    public class CheckoutResponse
    {
        public bool Success { get; set; }
        public string RedirectUrl { get; set; }
        public string TransactionID { get; set; }
    }
}
