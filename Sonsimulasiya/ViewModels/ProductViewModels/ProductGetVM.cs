using Sonsimulasiya.Models;

namespace Sonsimulasiya.ViewModels.ProductViewModels
{
    public class ProductGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

    }
}
