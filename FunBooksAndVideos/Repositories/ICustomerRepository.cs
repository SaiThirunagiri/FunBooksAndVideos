using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(long customerId);

        List<Customer> GetAll();
        void Save(Customer customer);
    }
}
