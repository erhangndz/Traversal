using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class InfoController : Controller
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            var values = _infoService.TGetList();
            return View(values);
        }

        public IActionResult DeleteInfo(int id)
        {
            var values = _infoService.TGetByID(id);
           
            _infoService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInfo(Info p)
        {
           
            _infoService.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateInfo(int id)
        {
            var values = _infoService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateInfo(Info p)
        {
            
            _infoService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
