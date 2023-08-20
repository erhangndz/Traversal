using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TGetActives();
            return View(values);
        }

        public IActionResult DeleteContactUs(int id)
        {
            var values = _contactUsService.TGetByID(id);
            values.MessageStatus = false;
            _contactUsService.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}
