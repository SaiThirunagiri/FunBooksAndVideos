using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Services
{
    public class PurchaseOrderProcessorService : IPurchaseOrderProcessorService
    {
        private readonly ICustomerService _customerService;
        private readonly IShippingService _shippingService;
        private readonly List<IBusinessRules>   _businessRules;
        public PurchaseOrderProcessorService(ICustomerService customerService,IShippingService shippingService) {
          _customerService = customerService;
            _shippingService = shippingService;

            _businessRules = new List<IBusinessRules>
            {
                new MembershipRule(_customerService),
                new ShippingRule(_customerService, _shippingService)
            };
        }
        
        public void ProcessPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            if(purchaseOrder == null) throw new ArgumentNullException(nameof(purchaseOrder));
            _businessRules.ForEach(x => x.ProcessRule(purchaseOrder));
        }
        
    }
}
