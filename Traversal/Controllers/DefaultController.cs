using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public DefaultController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult Subscribe()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Subscribe(Subscribe p)
        {
           _subscribeService.TInsert(p);
            return NoContent();
        }
    }

   
}
