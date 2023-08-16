using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.AdminDashboard
{
    public class _DashboardTransaction:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
