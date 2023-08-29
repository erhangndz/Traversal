using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberLayout
{
    public class MemberLayoutSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
