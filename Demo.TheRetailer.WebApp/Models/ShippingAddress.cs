namespace Demo.TheRetailer.WebApp.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Postcode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set;}
        public string City { get; set;}
        public bool Default { get; set; }
        public int UserId { get; set; }

    }
}
