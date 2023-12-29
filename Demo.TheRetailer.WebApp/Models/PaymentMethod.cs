namespace Demo.TheRetailer.WebApp.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Alias { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationDate { get; set;}
        public string SecurityCode { get; set; }
        public bool Default { get; set; }
        public int UserId { get; set; }
    }
}
