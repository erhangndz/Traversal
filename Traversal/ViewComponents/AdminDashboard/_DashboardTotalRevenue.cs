using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.AdminDashboard
{
    public class _DashboardTotalRevenue:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
