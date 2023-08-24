using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Destination
{
    public class _TourGuidesDetails:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _TourGuidesDetails(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _destinationService.TGetAll().Where(x=>x.DestinationID==id).ToList();
            
            return View(values);
        }
    }
}
