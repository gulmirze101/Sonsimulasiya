using System.ComponentModel.DataAnnotations;

namespace Sonsimulasiya.ViewModels.ProductViewModels
{
    public class ProductCreateVM
    {
        [Required, MaxLength(256), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(1024)]
        public string Description { get; set; } = string.Empty;

        [Required, Range(0,99999999.99)]
        public decimal Price { get; set; }

        [Required]
        public IFormFile Image { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

    }
}
