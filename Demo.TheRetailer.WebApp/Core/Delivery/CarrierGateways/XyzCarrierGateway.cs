using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery.CarrierGateways
{
    public class XyzCarrierGateway : ICarrierGateway
    {
        public Task<IEnumerable<DeliveryOption>> GetAsync(string originPostcode, string destinationPostcode, DateTime collectionDate)
        {
            IEnumerable<DeliveryOption> options = new[]
            {
                new DeliveryOption
                {
                    Carrier = "XYZ Carrier",
                    CarrierService = "2Day",
                    Cost = 4.99m,
                    MaxTransitTime = 2,
                    MinTransitTime = 3
                },
                new DeliveryOption
                {
                    Carrier = "XYZ Carrier",
                    CarrierService = "Next Day",
                    Cost = 7.99m,
                    MaxTransitTime = 1,
                    MinTransitTime = 1
                }
            };

            return Task.FromResult(options);
        }
    }
}
