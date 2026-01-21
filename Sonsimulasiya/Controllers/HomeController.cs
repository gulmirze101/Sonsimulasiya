using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Sonsimulasiya.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
