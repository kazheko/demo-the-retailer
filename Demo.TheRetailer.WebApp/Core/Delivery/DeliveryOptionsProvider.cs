using Demo.TheRetailer.WebApp.Core.Delivery.CarrierGateways;
using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery
{
    public class DeliveryOptionsProvider : IProvideDeliveryOptions
    {
        private const string StorePostcode = "M1 4ET";

        private readonly IEnumerable<ICarrierGateway> _providers;

        public DeliveryOptionsProvider(IEnumerable<ICarrierGateway> providers)
        {
            _providers = providers;
        }

        public async Task<IEnumerable<DeliveryOption>> GetAsync(string destinationPostcode)
        {
            var collectionDate = DateTime.Now;

            var allOptions = await GetAllOptions(StorePostcode, destinationPostcode, collectionDate);

            var options = new[]
            {
                GetCheapestOption(allOptions),
                GetExpeditedOption(allOptions)
            };

            return options.OfType<DeliveryOption>();
        }

        private async Task<IList<DeliveryOption>> GetAllOptions(string originalPostcode, string destinationPostcode, DateTime collectionDate)
        {
            var tasks = _providers.Select(x => x.GetAsync(originalPostcode, destinationPostcode, collectionDate));

            var options = await Task.WhenAll(tasks);

            return options.SelectMany(x => x).ToList();
        }

        private static DeliveryOption? GetCheapestOption(IEnumerable<DeliveryOption> options)
        {
            var option = options.MinBy(x => x.Cost);

            option?.AsStandardDelivery();

            return option;
        }

        private static DeliveryOption? GetExpeditedOption(IEnumerable<DeliveryOption> options)
        {
            var option = options
                .OrderBy(x => x.MinTransitTime)
                .ThenBy(x => x.MaxTransitTime)
                .FirstOrDefault();

            option?.AsExpeditedDelivery();

            return option;
        }
    }
}
