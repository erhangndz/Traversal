using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Destination
{
    public class _TourGuidesDetails:ViewComponent
    {
        private readonly IGuideService _guideService;

        public _TourGuidesDetails(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetByID(2);
            
            return View(values);
        }
    }
}
