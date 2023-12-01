using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery
{
    public class DeliveryOptionsProvider
    {
        private readonly IEnumerable<IProvideDeliveryOptions> _providers;

        public DeliveryOptionsProvider(IEnumerable<IProvideDeliveryOptions> providers)
        {
            _providers = providers;
        }

        public IEnumerable<DeliveryOption> GetDeliveryOptions(string originPostcode, string destinationPostcode, DateTime shippingDate)
        {
            var allOptions = _providers.AsParallel()
                .SelectMany(x => x.Get(originPostcode, destinationPostcode, shippingDate))
                .ToList();

            var options = new[]
            {
                GetCheapestOption(allOptions),
                GetExpeditedOption(allOptions)
            };

            return options
                .OfType<DeliveryOption>();
        }

        private static DeliveryOption? GetCheapestOption(IEnumerable<DeliveryOption> options)
        {
            return options.MinBy(x => x.Cost);
        }

        private static DeliveryOption? GetExpeditedOption(IEnumerable<DeliveryOption> options)
        {
            return options
                .OrderBy(x=>x.MinTransitTime)
                .ThenBy(x=>x.MaxTransitTime)
                .FirstOrDefault();
        }
    }
}
