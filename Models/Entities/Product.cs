using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public string? ImagePath { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // افزودن خصوصیت ناوبری برای تصاویر
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}