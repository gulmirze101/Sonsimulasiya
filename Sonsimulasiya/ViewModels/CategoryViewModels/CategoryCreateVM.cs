using System.ComponentModel.DataAnnotations;

namespace Sonsimulasiya.ViewModels.CategoryViewModels
{
    public class CategoryCreateVM
    {
        [Required, MaxLength(256), MinLength(3)]
        public string Name { get; set; } = string.Empty;
    }
}
