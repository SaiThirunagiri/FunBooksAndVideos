using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services
{
    public interface IPurchaseOrderProcessorService
    {
        void ProcessPurchaseOrderAsync(PurchaseOrder purchaseOrder);
    }
}
