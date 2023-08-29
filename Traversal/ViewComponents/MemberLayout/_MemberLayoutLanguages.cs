using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberLayout
{
    public class _MemberLayoutLanguages:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
