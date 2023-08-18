using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class GuideController : Controller
	{
		private readonly IGuideService _guideService;

		public GuideController(IGuideService guideService)
		{
			_guideService = guideService;
		}

		public IActionResult Index()
		{
			var values= _guideService.TGetList();
			return View(values);
		}

		public IActionResult DeleteGuide(int id)
		{
			var values = _guideService.TGetByID(id);
			if (values.Status == true)
			{
				values.Status = false;
			}
			else
			{
				values.Status = true;
			}
			_guideService.TUpdate(values);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult AddGuide()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddGuide(Guide p)
		{
			p.Status=true;
			_guideService.TInsert(p);
			return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
			var values = _guideService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateGuide(Guide p)
        {
            _guideService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
