using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

       

        public IActionResult UserComments(int id)
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        public IActionResult UserReservations(int id)
        {
            ViewBag.v = "Kullanıcının Rezervasyonu Bulunamadı!";
            var values = _reservationService.TGetAll().Where(x=>x.AppUserID==id).ToList();
            return View(values);
        }
    }
}
