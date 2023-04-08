using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services.BusinessRules;
using FunBooksAndVideos.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Tests.RulesTest
{
    [TestFixture]
    public class ShippingRuleTests
    {
        private Mock<ICustomerService> _customerServiceMock;
        private Mock<IShippingService> _shippingServiceMock;
        private ShippingRule _shippingRule;

        [SetUp]
        public void Setup()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _shippingServiceMock = new Mock<IShippingService>();
            _shippingRule = new ShippingRule(_customerServiceMock.Object, _shippingServiceMock.Object);
        }

        [Test]
        public void ProcessRule_Should_ProcessShipping_When_PurchaseOrderContainsPhysicalProduct()
        {
            // Arrange
            var customer = new Customer { CustomerId = 100, Name = "John" };
            _customerServiceMock.Setup(x => x.GetCustomer(It.IsAny<long>())).Returns(customer);

            var products = new List<Product>
        {
            new Product { Name = "Book", Price = 10.0m, ProductType = ProductType.Book, IsPhysicalCopyRequired = true },
            new Product {  Name = "CD", Price = 5.0m, ProductType = ProductType.Video, IsPhysicalCopyRequired = false }
        };

            var purchaseOrder = new PurchaseOrder
            {
                OrderNumber = 1,
                CustomerId = 100,
                Products = products
            };

            // Act
            _shippingRule.ProcessRule(purchaseOrder);

            // Assert
            _customerServiceMock.Verify(x => x.GetCustomer(purchaseOrder.CustomerId), Times.Once);
            _shippingServiceMock.Verify(x => x.ProcessShipping(customer, products), Times.Once);
        }

        [Test]
        public void ProcessRule_Should_NotProcessShipping_When_PurchaseOrderDoesNotContainPhysicalProduct()
        {
            // Arrange
            var customer = new Customer { CustomerId = 100, Name = "John" };
            _customerServiceMock.Setup(x => x.GetCustomer(It.IsAny<long>())).Returns(customer);

            var products = new List<Product>
        {
            new Product {  Name = "Book", Price = 10.0m, ProductType = ProductType.Book, IsPhysicalCopyRequired = false },
            new Product {  Name = "CD", Price = 5.0m, ProductType = ProductType.Video, IsPhysicalCopyRequired = false }
        };

            var purchaseOrder = new PurchaseOrder
            {
                OrderNumber = 1,
                CustomerId = 100,
                Products = products
            };

            // Act
            _shippingRule.ProcessRule(purchaseOrder);

            // Assert
            _customerServiceMock.Verify(x => x.GetCustomer(purchaseOrder.CustomerId), Times.Never);
            _shippingServiceMock.Verify(x => x.ProcessShipping(It.IsAny<Customer>(), It.IsAny<List<Product>>()), Times.Never);
        }
    }
}
