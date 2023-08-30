using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class Feature2Controller : Controller
    {
        private readonly IFeature2Service _feature2Service;

        public Feature2Controller(IFeature2Service feature2Service)
        {
            _feature2Service = feature2Service;
        }

        public IActionResult Index()
        {
            var values = _feature2Service.TGetList().Where(x => x.Status == true).ToList();
            return View(values);
        }

        public IActionResult DeleteFeature(int id)
        {
            var values = _feature2Service.TGetByID(id);
            values.Status = false;
            _feature2Service.TUpdate(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(Feature2 p)
        {
            p.Status = true;
            _feature2Service.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var values = _feature2Service.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature2 p)
        {
            p.Status = true;
            _feature2Service.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
