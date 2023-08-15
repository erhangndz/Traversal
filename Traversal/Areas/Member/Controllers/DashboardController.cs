using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name= user.NameSurname;
            ViewBag.image = user.Image;
            ViewBag.mail = user.Email;
            ViewBag.phone = user.PhoneNumber;
            return View();
        }
    }
}
