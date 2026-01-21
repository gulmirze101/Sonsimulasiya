using System.ComponentModel.DataAnnotations;

namespace Sonsimulasiya.ViewModels.CategoryViewModels
{
    public class CategoryUpdateVM
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(256), MinLength(3)]
        public string Name { get; set; } = string.Empty;
    }
}
