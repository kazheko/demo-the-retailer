namespace Demo.TheRetailer.WebApp.Models
{
    public class DeliveryOption
    {
        public string Carrier { get; set; }
        public string CarrierService { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public decimal Cost { get; set; }
        public int MinTransitTime { get; set; }
        public int MaxTransitTime { get; set; }
    }
}
