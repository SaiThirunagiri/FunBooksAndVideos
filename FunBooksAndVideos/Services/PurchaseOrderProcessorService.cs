using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services.BusinessRules;

namespace FunBooksAndVideos.Services
{
    public class PurchaseOrderProcessorService : IPurchaseOrderProcessorService
    {
        private readonly ICustomerService _customerService;
        private readonly IShippingService _shippingService;
        private readonly IList<IBusinessRules> _businessRules;
        public PurchaseOrderProcessorService(ICustomerService customerService, 
            IShippingService shippingService,
            IList<IBusinessRules> businessRules)
        {
            _customerService = customerService;
            _shippingService = shippingService;
            _businessRules = businessRules;
           
        }

        public void ProcessPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null) throw new ArgumentNullException(nameof(purchaseOrder));
            _businessRules.ToList<IBusinessRules>().ForEach(x => x.ProcessRule(purchaseOrder));
        }

    }
}
