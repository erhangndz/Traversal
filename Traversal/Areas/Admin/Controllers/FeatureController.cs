using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IActionResult Index()
        {
            var values = _featureService.TGetList().Where(x => x.Status1 == true).ToList();
            return View(values);
        }

        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            values.Status1 = false;
            _featureService.TUpdate(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(Feature p)
        {
            p.Status1 = true;
            _featureService.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature p)
        {
            p.Status1=true;
            _featureService.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}
