using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.Models.Dtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public required string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Range(0.01, 1000000, ErrorMessage = "Price must be between $0.01 and $1,000,000.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(0, 10000, ErrorMessage = "Stock quantity cannot be negative or exceed 10,000.")]
        public int StockQuantity { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}