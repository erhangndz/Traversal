using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberDashboard
{
    public class _PlatformSettings:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
