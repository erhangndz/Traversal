using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Guide
{
    public class _Guides:ViewComponent
    {
        private readonly IGuideService _guideService;

        public _Guides(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
    }
}
