using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Exceptions;
using FunBooksAndVideos.Repositories;

namespace FunBooksAndVideos.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        public void  Activate(long customerId)
        {
            var customer = GetCustomer(customerId);
            if (customer == null) throw new CustomerNotFoundException("Customer not found");
            customer.IsActive = true;
           
        }

        public Customer GetCustomer(long customerId)
        {
            return _customerRepository.Get(customerId);
        }

        public void RegisterCustomer(Customer customer)
        {
            _customerRepository.Save(customer);
        }


    }
}
