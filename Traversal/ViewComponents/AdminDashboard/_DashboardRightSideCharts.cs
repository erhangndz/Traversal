using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.AdminDashboard
{
    public class _DashboardRightSideCharts:ViewComponent
    {
        

        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.destination = c.Destinations.Count();
            ViewBag.guests = c.Users.Count();
;            return View();
        }
    }
}
