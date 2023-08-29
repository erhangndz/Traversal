using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar:ViewComponent
    {
        UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name=user.NameSurname;
            ViewBag.image = user.Image;

            return View();
        }
    }
}
