using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Repositories;

namespace FunBooksAndVideos.Tests
{


    [TestFixture]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new CustomerRepository();
        }

        [Test]
        public void Save_AddsNewCustomerToRepository()
        {
            // Arrange
            var customer = new Customer() { CustomerId = 6, Address = "Address 6", IsActive = false, Name = "Sixth Cust" };

            // Act
            _repository.Save(customer);

            // Assert
            var customers = _repository.GetAll();
            Assert.IsTrue(customers.Contains(customer));
        }

        [Test]
        public void GetAll_ReturnsAllCustomers()
        {
            // Arrange
            var expectedCustomers = new List<Customer>
        {
            new Customer() { CustomerId = 1, Address = "Address 1", IsActive = false, Name = "First Cust" },
            new Customer() { CustomerId = 2, Address = "Address 2", IsActive = false, Name = "Second Cust" },
            new Customer() { CustomerId = 3, Address = "Address 3", IsActive = false, Name = "Third Cust" },
            new Customer() { CustomerId = 4, Address = "Address 4", IsActive = false, Name = "Fourth Cust" },
            new Customer() { CustomerId = 5, Address = "Address 5", IsActive = false, Name = "Fifth Cust" }
        };

            // Act
            var actualCustomers = _repository.GetAll();

            // Assert

            CollectionAssert.AreEqual(expectedCustomers, actualCustomers);
        }

        [Test]
        public void Get_ReturnsCustomerWithSpecifiedId()
        {
            // Arrange
            var expectedCustomer = new Customer() { CustomerId = 3, Address = "Address 3", IsActive = false, Name = "Third Cust" };

            // Act
            var actualCustomer = _repository.Get(3);

            // Assert
            Assert.That(actualCustomer, Is.EqualTo(expectedCustomer));
        }

        [Test]
        public void Get_ReturnsNullIfCustomerWithSpecifiedIdNotFound()
        {
            // Arrange

            // Act
            var actualCustomer = _repository.Get(10);

            // Assert
            Assert.IsNull(actualCustomer);
        }

        [Test]
        public void Save_WithNullCustomer_DoesNotAddCustomerToRepository()
        {
            // Arrange
            Customer customer = null;

            // Act
            _repository.Save(customer);

            // Assert
            var customers = _repository.GetAll();
            CollectionAssert.DoesNotContain(customers, customer);
        }

        [Test]
        public void GetAll_WhenRepositoryIsNull_ReturnsEmptyList()
        {
            // Arrange
            _repository = new CustomerRepository { _customers = null };

            // Act
            var actualCustomers = _repository.GetAll();

            // Assert
            CollectionAssert.IsEmpty(actualCustomers);
        }

        [Test]
        public void Get_WhenRepositoryIsNull_ReturnsNull()
        {
            // Arrange
            _repository = new CustomerRepository { _customers = null };

            // Act
            var actualCustomer = _repository.Get(1);

            // Assert
            Assert.IsNull(actualCustomer);
        }
    }

}
