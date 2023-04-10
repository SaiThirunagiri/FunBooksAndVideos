using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Entities
{
    public class Product
    {
        public ProductType ProductType { get; set; }
        public string? Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        public bool IsPhysicalCopyRequired { get; set; }

    }
    public enum ProductType
    {
        Book,
        Video,
        BookClubMembership,
        VideoClubMemberShip

    }
}
