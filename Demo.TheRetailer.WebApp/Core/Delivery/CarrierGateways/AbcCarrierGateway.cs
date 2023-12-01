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
                    CarrierService = "Standard Delivery (ABC Carrier 2Day)",
                    Cost = 4.99m,
                    MaxTransitTime = 2,
                    MinTransitTime = 3
                },
                new DeliveryOption
                {
                    CarrierService = "Expedited Delivery (ABC Carrier Next Day)",
                    Cost = 6.99m,
                    MaxTransitTime = 1,
                    MinTransitTime = 1
                }
            };
        }
    }
}
