using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery
{
    public interface IProvideDeliveryOptions
    {
        Task<IEnumerable<DeliveryOption>> GetAsync(string destinationPostcode);
    }
}
