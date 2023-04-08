using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services.BusinessRules
{
    public interface IBusinessRules
    {
        void  ProcessRule(PurchaseOrder purchaseOrder);
    }
}
