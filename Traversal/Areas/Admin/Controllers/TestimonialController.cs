using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var values= _testimonialService.TGetList().Where(x=>x.Status==true).ToList();
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            values.Status = false;
            _testimonialService.TUpdate(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            p.Status = true;
            _testimonialService.TInsert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
           var values = _testimonialService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial p)
        {
            p.Status=true;
            _testimonialService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
