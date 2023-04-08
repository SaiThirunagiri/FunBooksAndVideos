using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public  List<Customer>? _customers;
        public CustomerRepository()
        {
            _customers = new List<Customer> { new Customer() { CustomerId = 1, Address = "Address 1", IsActive = false, Name = "First Cust" },
                 new Customer() { CustomerId = 2, Address = "Address 2", IsActive = false, Name = "Second Cust" },
                 new Customer() { CustomerId = 3, Address = "Address 3", IsActive = false, Name = "Third Cust" },
                 new Customer() { CustomerId = 4, Address = "Address 4", IsActive = false, Name = "Fourth Cust" },
                 new Customer() { CustomerId = 5, Address = "Address 5", IsActive = false, Name = "Fifth Cust" }
            };
        }
        public void Save(Customer customer)
        {
            if(customer != null)
            {
                _customers?.Add(customer);
            }
           
        }

        public List<Customer> GetAll()
        {
             return _customers ?? new List<Customer>();
        }

        public Customer? Get(long customerId)
        {
           return _customers?.Find(x =>  (x.CustomerId == customerId));
        }
    }
}
