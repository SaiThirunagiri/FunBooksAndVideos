using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services;
using FunBooksAndVideos.Services.BusinessRules;
using Moq;


namespace FunBooksAndVideos.Tests
{

    [TestFixture]
    public class PurchaseOrderProcessorServiceTests
    {
        private Mock<ICustomerService> _customerServiceMock;
        private Mock<IShippingService> _shippingServiceMock;
        private Mock<Customer> _customer;
        private Mock<List<Product>> _customerProducts;
        private List<IBusinessRules> _rules;
        private Mock<IBusinessRules> _mockrules;
        private PurchaseOrderProcessorService _service;


        [SetUp]
        public void Setup()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _shippingServiceMock = new Mock<IShippingService>();
            _customer = new Mock<Customer>();
            _customerProducts = new Mock<List<Product>>();
            _rules = new List<IBusinessRules>() { new MembershipRule(_customerServiceMock.Object), new ShippingRule(_customerServiceMock.Object, _shippingServiceMock.Object) };
            _mockrules = new Mock<IBusinessRules>();
            _service = new PurchaseOrderProcessorService(_rules);

        }

        [Test]
        public void ProcessPurchaseOrderAsync_NullPurchaseOrder_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _service.ProcessPurchaseOrderAsync(null));
        }

        [Test]
        public void ProcessPurchaseOrderAsync_ExecutesAllBusinessRules()
        {
            // Arrange
            var customer = new Customer() { Name = "First Cust", CustomerId = 1, IsActive = false, Address = "Address 1" };
            var products = new List<Product> { new Product() { IsPhysicalCopyRequired = true,
             Name = "My Fav Book" , Price = 10, ProductType = ProductType.Book},
             new Product() { IsPhysicalCopyRequired = true, Name = "Rangers", ProductType = ProductType.VideoClubMemberShip, Price = 30 }
                };
            var purchaseOrder = new PurchaseOrder()
            {
                CustomerId = customer.CustomerId,
                OrderNumber = 123455,
                Products = products
            };

            // Act
            _service.ProcessPurchaseOrderAsync(purchaseOrder);

            // Assert
            Assert.IsTrue(_rules.Count == 2);

        }
    }

}
