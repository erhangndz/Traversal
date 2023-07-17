using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _IndexDestinations:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _IndexDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
           var values= _destinationService.TGetList().Take(8).ToList();
            return View(values);
        }
    }
}
