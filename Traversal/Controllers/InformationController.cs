using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
