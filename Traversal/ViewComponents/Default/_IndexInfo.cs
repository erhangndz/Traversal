using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _IndexInfo:ViewComponent
    {
        private readonly IInfoService _infoService;

        public _IndexInfo(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _infoService.TGetList();
            return View(values);
        }
    }
}
