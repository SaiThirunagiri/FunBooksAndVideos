using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services.BusinessRules
{
    public class MembershipRule : IBusinessRules
    {
        private readonly ICustomerService _customerService;
        public MembershipRule(ICustomerService customerService) {
            _customerService = customerService;
        }
        public void ProcessRule(PurchaseOrder purchaseOrder)
        {
           if(purchaseOrder.Products.Any(x => (x.ProductType == ProductType.BookClubMembership || 
           x.ProductType == ProductType.VideoClubMemberShip))) 
           {
                _customerService.Activate(purchaseOrder.CustomerId);
           }
        }
    }
}
