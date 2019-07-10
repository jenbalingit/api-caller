namespace PopAppShops.API.DTO
{
    public class Address 
    {
        public Address() { }
        
        public string AddressLine1 { get; set; } // bldg no, blk, lot, street

        public string AddressLine2 { get; set; }

        public string Subdivision { get; set; }
        
        public string City { get; set; } // or Municipality

        public string Province { get; set; }
        
        public string Region { get; set; }
        
        public int ZipCode { get; set; }
    }
}
