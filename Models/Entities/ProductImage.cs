namespace ECommercePlatform.Models.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public required string ImagePath { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}