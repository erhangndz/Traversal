using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Member")]
    public class DestinationController : Controller
    {
        IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values= _destinationService.TGetList();
            return View(values);
        }

        public IActionResult SearchCities(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = from x in _destinationService.TGetList() select x;
            if(!string.IsNullOrEmpty(searchString) )
            {
                values= values.Where(x=>x.City.Contains(searchString));
            }
            return View(values.ToList());
        }
    }
}
