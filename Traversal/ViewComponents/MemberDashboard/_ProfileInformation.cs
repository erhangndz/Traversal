using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberDashboard
{
    public class _ProfileInformation:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
