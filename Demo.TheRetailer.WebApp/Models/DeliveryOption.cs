namespace Demo.TheRetailer.WebApp.Models
{
    public class DeliveryOption
    {
        public string Carrier { get; set; }
        public string CarrierService { get; set; }
        public DeliveryType DeliveryType { get; private set; }
        public decimal Cost { get; set; }
        public int MinTransitTime { get; set; }
        public int MaxTransitTime { get; set; }

        public void AsStandardDelivery()
        {
            DeliveryType = DeliveryType.StandardDelivery;
        }

        public void AsExpeditedDelivery()
        {
            DeliveryType = DeliveryType.ExpeditedDelivery;
        }

    }
}
