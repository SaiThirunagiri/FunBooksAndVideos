using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services;
using Moq;

namespace FunBooksAndVideos.Tests.ServicesTests
{
    [TestFixture]
    public class ShippingServiceTests
    {
        private Mock<IShippingService> _shippingServiceMock;
        private ShippingService _shippingService;
        private Customer _customer;
        private List<Product> _products;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer
            {
                Name = "Lia",
                Address = "345 Main St."
            };

            _products = new List<Product>
        {
            new Product { Name = "Product 1", Price = 10 },
            new Product { Name = "Product 2", Price = 20 },
            new Product { Name = "Product 3", Price = 30 }
        };

            _shippingServiceMock = new Mock<IShippingService>();
            _shippingService = new ShippingService();
        }

        [Test]
        public void ProcessShipping_WithValidCustomerAndProducts_ReturnsShippingSlip()
        {
            // Arrange

            // Act
            var result = _shippingService.ProcessShipping(_customer, _products);

            // Assert
            Assert.IsInstanceOf<ShippingSlip>(result);
        }

        [Test]
        public void GenerateShippingSlip_WithValidCustomer_ReturnsShippingSlip()
        {
            // Arrange

            // Act
            var result = _shippingService.GenerateShippingSlip(_customer);

            // Assert
            Assert.IsInstanceOf<ShippingSlip>(result);
        }

        [Test]
        public void GenerateShippingSlip_WithValidCustomer_SetsShippingSlipFields()
        {
            // Arrange

            // Act
            var result = _shippingService.GenerateShippingSlip(_customer);

            // Assert
            Assert.That(result.CustomerName, Is.EqualTo(_customer.Name));
            Assert.That(result.ShippingAddress, Is.EqualTo(_customer.Address));
            Assert.IsInstanceOf<int>(result.InvoiceNumber);
            Assert.IsInstanceOf<int>(result.Shipmentnumber);
            Assert.That(result.ShippingDate.Date, Is.EqualTo(DateTime.Now.Date));
        }
    }

}
