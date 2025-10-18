using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; } // ایمیل منحصربه‌فرد

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public string? ProfileImagePath { get; set; } // مسیر عکس پروفایل
    }
}