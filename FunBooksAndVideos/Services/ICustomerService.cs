using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services
{
    public interface ICustomerService
    {
        void RegisterCustomer(Customer customer);
        void Activate(long customerId);

        Customer GetCustomer(long customerId);
        List<Customer> GetAllCustomer();
    }
}
