using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
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

		public IActionResult ChangeGuide(int id)
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
			GuideValidator validator = new GuideValidator();
			ValidationResult result = validator.Validate(p);
			if (result.IsValid)
			{
                p.Status = true;
                _guideService.TInsert(p);
                return RedirectToAction("Index");
            }
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}
			
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

		public IActionResult DeleteGuide(int id)
		{
			var values = _guideService.TGetByID(id);
			_guideService.TDelete(values);
			return RedirectToAction("Index");
		}
    }
}
