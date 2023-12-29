using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery.CarrierGateways
{
    public class AbcCarrierGateway : IProvideDeliveryOptions
    {
        public IEnumerable<DeliveryOption> Get(string originPostcode, string destinationPostcode, DateTime shippingDate)
        {
            return new[]
            {
                new DeliveryOption
                {
                    Carrier = "ABC Carrier",
                    CarrierService = "2Day",
                    DeliveryType = DeliveryType.StandardDelivery,
                    Cost = 4.99m,
                    MaxTransitTime = 2,
                    MinTransitTime = 3
                },
                new DeliveryOption
                {
                    Carrier = "ABC Carrier",
                    CarrierService = "Next Day",
                    DeliveryType = DeliveryType.ExpeditedDelivery,
                    Cost = 6.99m,
                    MaxTransitTime = 1,
                    MinTransitTime = 1
                }
            };
        }
    }
}
