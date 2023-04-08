namespace FunBooksAndVideos.Entities
{
    public class Product
    {
        public ProductType ProductType { get; set; }
        public string? Name { get; set; }

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
