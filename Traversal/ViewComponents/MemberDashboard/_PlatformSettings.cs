using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberDashboard
{
    public class _PlatformSettings:ViewComponent
    {
        UserManager<AppUser> _userManager;

        public _PlatformSettings(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var c = new Context();
            ViewBag.activeReservations = c.Reservations.Where(x=>x.AppUserID==user.Id && x.Status=="Onaylandı").Count();
            ViewBag.pastReservations = c.Reservations.Where(x => x.AppUserID == user.Id && x.Status == "Geçmiş Rezervasyon").Count();
            ViewBag.waitApproveReservations= c.Reservations.Where(x => x.AppUserID == user.Id && x.Status == "Onay Bekliyor").Count();
            ViewBag.totalDestination = c.Destinations.Count();
            ViewBag.totalGuide = c.Guides.Count();
            ViewBag.totalUsers = c.Users.Count();

            return View();
        }
    }
}
