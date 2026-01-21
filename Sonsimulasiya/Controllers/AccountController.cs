using System.Configuration.Internal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Sonsimulasiya.Models;
using Sonsimulasiya.ViewModels.UserViewModels;

namespace Sonsimulasiya.Controllers
{

    public class AccountController(UserManager<AppUser>  _userManager, SignInManager<AppUser> _signInManager, RoleManager<IdentityRole> _roleManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);


            }

            AppUser user = new()
            {
                FullName = vm.FullName,
                UserName = vm.UserName,
                Email = vm.Email
            };

            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);

                }
                return View(vm);
            }

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);


            }

            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user is null)
            {
                ModelState.AddModelError("", "Email or password is wrong");
            }

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong");
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
