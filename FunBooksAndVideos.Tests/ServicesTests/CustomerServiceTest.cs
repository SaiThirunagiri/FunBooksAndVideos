using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Exceptions;
using FunBooksAndVideos.Repositories;
using FunBooksAndVideos.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Tests.ServicesTests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private ICustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_customerRepositoryMock.Object);
        }

        [Test]
        public void Activate_CustomerNotFound_ThrowsException()
        {
            // Arrange
            long customerId = 1;
            _customerRepositoryMock.Setup(x => x.Get(customerId)).Returns<Customer>(null);

            // Act & Assert
            Assert.Throws<CustomerNotFoundException>(() => _customerService.Activate(customerId));
        }

        [Test]
        public void Activate_CustomerFound_SetsIsActiveTrue()
        {
            // Arrange
            long customerId = 1;
            var customer = new Customer { CustomerId = customerId, IsActive = false };
            _customerRepositoryMock.Setup(x => x.Get(customerId)).Returns(customer);

            // Act
            _customerService.Activate(customerId);

            // Assert
            Assert.IsTrue(customer.IsActive);
           
        }

        [Test]
        public void GetCustomer_CustomerNotFound_ReturnsNull()
        {
            // Arrange
            long customerId = 1;
            _customerRepositoryMock.Setup(x => x.Get(customerId)).Returns<Customer>(null);

            // Act
            var result = _customerService.GetCustomer(customerId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetCustomer_CustomerFound_ReturnsCustomer()
        {
            // Arrange
            long customerId = 1;
            var customer = new Customer { CustomerId = customerId, Name = "Dave" };
            _customerRepositoryMock.Setup(x => x.Get(customerId)).Returns(customer);

            // Act
            var result = _customerService.GetCustomer(customerId);

            // Assert
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void RegisterCustomer_CustomerSavedToRepository()
        {
            // Arrange
            var customer = new Customer { Name = "Dave" };

            // Act
            _customerService.RegisterCustomer(customer);

            // Assert
            _customerRepositoryMock.Verify(x => x.Save(customer), Times.Once);
        }
    }
}
