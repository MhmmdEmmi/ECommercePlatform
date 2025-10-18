using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        // رابطه یک-به-چند با محصولات
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}