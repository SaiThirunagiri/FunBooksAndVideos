using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services.BusinessRules
{
    public class ShippingRule : IBusinessRules
    {
        private readonly ICustomerService _customerService;

        private readonly IShippingService _shippingService;
        public ShippingRule(ICustomerService customerService,
            IShippingService shippingService)
        {
            _customerService = customerService;     
            _shippingService = shippingService;
        }
        public void ProcessRule(PurchaseOrder purchaseOrder)
        {
           if( purchaseOrder.Products.Any(x => x.IsPhysicalCopyRequired))
            {
                _shippingService.ProcessShipping(_customerService.GetCustomer(purchaseOrder.CustomerId),
                    purchaseOrder.Products);
            }
        }
    }
}
