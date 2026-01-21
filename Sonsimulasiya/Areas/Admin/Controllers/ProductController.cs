using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sonsimulasiya.Contexts;
using Sonsimulasiya.Helpers;
using Sonsimulasiya.ViewModels.ProductViewModels;

namespace Sonsimulasiya.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        private readonly string _folderPath;

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Select(x => new ProductGetVM()
            {
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
                Price = x.Price,
                CategoryName = x.Category.Name
            }).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            await _sendCategoriesWithViewBag();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var isExistCategory = await _context.Categories.AnyAsync(x=>x.Id ==vm.CategoryId);

            if (!isExistCategory)
            {
                ModelState.AddModelError("CategoryId", "This Category does not exist");
                return View(vm);
            }
            if (!vm.Image.CheckSize(2))
            {
                return View(vm);
            }
            if (!vm.Image.CheckType("Image"))
            {
                return View(vm);
            }


            
        }
        private  async Task _sendCategoriesWithViewBag()
        {
            var categories = await _context.Categories.Select(x => new  SelectListItem(){
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToListAsync();

            ViewBag.Categories = categories;
        }
    }
}
