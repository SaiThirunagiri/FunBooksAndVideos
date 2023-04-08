using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services.BusinessRules;
using FunBooksAndVideos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace FunBooksAndVideos.Tests.RulesTest
{
    [TestFixture]
    public class MembershipRuleTests
    {
        private Mock<ICustomerService> _customerServiceMock;
        private MembershipRule _membershipRule;

        [SetUp]
        public void Setup()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _membershipRule = new MembershipRule(_customerServiceMock.Object);
        }

        [Test]
        public void ProcessRule_Should_ActivateMembership_When_PurchaseOrderContainsBookClubMembership()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder
            {
                OrderNumber = 1,
                CustomerId = 100,
                Products = new List<Product>
            {
                new Product {  Name = "Book Club Membership", Price = 10.0m, ProductType = ProductType.BookClubMembership }
            }
            };

            // Act
            _membershipRule.ProcessRule(purchaseOrder);

            // Assert
            _customerServiceMock.Verify(x => x.Activate(purchaseOrder.CustomerId), Times.Once);
        }

        [Test]
        public void ProcessRule_Should_ActivateMembership_When_PurchaseOrderContainsVideoClubMemberShip()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder
            {
                OrderNumber = 1,
                CustomerId = 100,
                Products = new List<Product>
            {
                new Product { Name = "Premium Membership", Price = 20.0m, ProductType = ProductType.VideoClubMemberShip }
            }
            };

            // Act
            _membershipRule.ProcessRule(purchaseOrder);

            // Assert
            _customerServiceMock.Verify(x => x.Activate(purchaseOrder.CustomerId), Times.Once);
        }

        [Test]
        public void ProcessRule_Should_NotActivateMembership_When_PurchaseOrderDoesNotContainMembership()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder
            {
                OrderNumber = 1,
                CustomerId = 100,
                Products = new List<Product>
            {
                new Product {  Name = "Book", Price = 10.0m, ProductType = ProductType.Book }
            }
            };

            // Act
            _membershipRule.ProcessRule(purchaseOrder);

            // Assert
            _customerServiceMock.Verify(x => x.Activate(It.IsAny<long>()), Times.Never);
        }
    }
}
