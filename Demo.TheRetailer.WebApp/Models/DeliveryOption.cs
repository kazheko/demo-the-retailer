namespace Demo.TheRetailer.WebApp.Models
{
    public class DeliveryOption
    {
        public string CarrierService { get; set; }
        public decimal Cost { get; set; }
        public int MinTransitTime { get; set; }
        public int MaxTransitTime { get; set; }
    }
}
