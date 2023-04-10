using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Entities
{
    public class PurchaseOrder
    {

        [RegularExpression(@"^\d{7}$", ErrorMessage = "Invoice number must be 7 digits")]
        public long OrderNumber { get; set; }

        [RegularExpression(@"^\d{7}$", ErrorMessage = "Invoice number must be 7 digits")]
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
