using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery
{
    public interface IProvideDeliveryOptions
    {
        IEnumerable<DeliveryOption> Get(string originPostcode, string destinationPostcode, DateTime shippingDate);
    }
}
