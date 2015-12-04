using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet5ng2seed.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnet5ng2seed.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Username, model.Password, true, false);

                if (result.Succeeded)
                {
                    return Redirect("/");
                }

                ModelState.AddModelError("", "Username or password is incorrect.");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return Redirect("/");
        }
    }
}
