using System.ComponentModel.DataAnnotations;

namespace ProductEngine.Models
{
    public class ProductCreateDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public decimal WholesalePrice { get; set; }

        [Required]
        public decimal MRP { get; set; }
    }
}
