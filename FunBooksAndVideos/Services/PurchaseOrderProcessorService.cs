using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services.BusinessRules;

namespace FunBooksAndVideos.Services
{
    public class PurchaseOrderProcessorService : IPurchaseOrderProcessorService
    {
        private readonly IList<IBusinessRules> _businessRules;
        public PurchaseOrderProcessorService(IList<IBusinessRules> businessRules)
        {
            _businessRules = businessRules;
        }

        public void ProcessPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null) throw new ArgumentNullException(nameof(purchaseOrder));
            _businessRules.ToList<IBusinessRules>().ForEach(x => x.ProcessRule(purchaseOrder));
        }

    }
}
