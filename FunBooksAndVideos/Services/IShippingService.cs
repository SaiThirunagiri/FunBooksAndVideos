using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services
{
    public interface IShippingService
    {
        ShippingSlip ProcessShipping(Customer customer,List<Product> products);
    }
}
