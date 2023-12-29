using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery.CarrierGateways
{
    public class AbcCarrierGateway : ICarrierGateway
    {
        public Task<IEnumerable<DeliveryOption>> GetAsync(string originPostcode, string destinationPostcode, DateTime collectionDate)
        {
            IEnumerable <DeliveryOption> options = new[]
            {
                new DeliveryOption
                {
                    Carrier = "ABC Carrier",
                    CarrierService = "2Day",
                    Cost = 4.99m,
                    MaxTransitTime = 2,
                    MinTransitTime = 3
                },
                new DeliveryOption
                {
                    Carrier = "ABC Carrier",
                    CarrierService = "Next Day",
                    Cost = 6.99m,
                    MaxTransitTime = 1,
                    MinTransitTime = 1
                }
            };

            return Task.FromResult(options);
        }
    }
}
