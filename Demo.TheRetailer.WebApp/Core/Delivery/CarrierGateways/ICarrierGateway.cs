using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Core.Delivery.CarrierGateways
{
    public interface ICarrierGateway
    {
        Task<IEnumerable<DeliveryOption>> GetAsync(string originPostcode, string destinationPostcode, DateTime collectionDate);
    }
}
