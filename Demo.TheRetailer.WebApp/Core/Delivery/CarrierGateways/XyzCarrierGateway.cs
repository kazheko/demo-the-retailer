using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery.CarrierGateways
{
    public class XyzCarrierGateway : IProvideDeliveryOptions
    {
        public IEnumerable<DeliveryOption> Get(string originPostcode, string destinationPostcode, DateTime shippingDate)
        {
            return new[]
            {
                new DeliveryOption
                {
                    Carrier = "XYZ Carrier",
                    CarrierService = "2Day",
                    DeliveryType = DeliveryType.StandardDelivery,
                    Cost = 4.99m,
                    MaxTransitTime = 2,
                    MinTransitTime = 3
                },
                new DeliveryOption
                {
                    Carrier = "XYZ Carrier",
                    CarrierService = "Next Day",
                    DeliveryType = DeliveryType.ExpeditedDelivery,
                    Cost = 7.99m,
                    MaxTransitTime = 1,
                    MinTransitTime = 1
                }
            };
        }
    }
}
