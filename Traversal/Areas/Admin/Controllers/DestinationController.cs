using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            p.Status = true;
            _destinationService.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
           _destinationService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
