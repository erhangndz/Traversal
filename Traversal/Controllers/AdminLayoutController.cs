using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    
    public class AdminLayoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminLayoutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<PartialViewResult> _NavbarPartial()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.NameSurname;
            ViewBag.image = user.Image;

            return PartialView();
        }
    }
}
