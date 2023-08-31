using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _IndexSlider:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _IndexSlider(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public IViewComponentResult Invoke()
        {
           var values= _destinationService.TGetAll();
            return View(values);
        }
    }
}
