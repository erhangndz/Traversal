using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Member.Models;
using System.IO;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();

            model.NameSurname = values.NameSurname;
            model.PhoneNumber = values.PhoneNumber;
            model.Email = values.Email;
            model.ImageURL = values.Image;
      
          
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid()+extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation,FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.Image = imagename;
            }

            user.NameSurname=p.NameSurname;
            user.Email=p.Email;
            user.PhoneNumber = p.PhoneNumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
