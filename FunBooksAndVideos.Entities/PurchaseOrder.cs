namespace FunBooksAndVideos.Entities
{
    public class PurchaseOrder
    {
        public long OrderNumber { get; set; }
        public long CustomerId { get; set; }
        public decimal Total
        {
            get
            {
                return Products.Sum(x => x.Price);
            }
        }

        public List<Product>? Products { get; set; }
    }
}
