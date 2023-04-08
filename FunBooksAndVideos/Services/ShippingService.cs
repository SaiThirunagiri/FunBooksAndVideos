using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services
{
    public class ShippingService : IShippingService
    {
        public ShippingSlip ProcessShipping(Customer customer, List<Product> products)
        {
            var slip = GenerateShippingSlip(customer);

            //Perform actual shipping for the products taken from input method parameter

            return slip;
        }

        public ShippingSlip GenerateShippingSlip(Customer customer)
        {
            return new ShippingSlip
            {
                CustomerName = customer.Name,
                InvoiceNumber = new Random(1).Next(),
                Shipmentnumber = new Random(1).Next(),
                ShippingAddress = customer.Address,
                ShippingDate = DateTime.Now
            };
        }
    }
}
    

