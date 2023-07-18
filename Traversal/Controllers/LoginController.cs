using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.Models;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> SignUp(RegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Email = p.Mail,
                NameSurname = p.NameSurname,
                UserName = p.Username,

            };

            if(p.Password==p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser,p.Password);


                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }

                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> SignIn(LoginViewModel p)
		{
            AppUser appUser = new AppUser()
            {
                UserName = p.Username,

            };
            var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Comment");
            }

            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                return View();
            }
			return View();
		}
	}
}
