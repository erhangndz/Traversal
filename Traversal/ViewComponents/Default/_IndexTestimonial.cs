using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _IndexTestimonial:ViewComponent
    {
        ITestimonialService _testimonialService;

        public _IndexTestimonial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _testimonialService.TGetList();
            return View(values);
        }
    }
}
