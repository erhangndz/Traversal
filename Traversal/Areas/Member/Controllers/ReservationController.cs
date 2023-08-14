using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IDestinationService destinationService, IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.NameSurname;
            ViewBag.v = "Onaylanan Rezervasyonunuz Bulunamadı!";
            var values=  _reservationService.TGetList().Where(x=>x.Status=="Onaylandı" && x.AppUserID==user.Id).ToList();
            return View(values);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.NameSurname;
            ViewBag.v = "Geçmiş Rezervasyonunuz Bulunamadı!";
            var values = _reservationService.TGetList().Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserID == user.Id).ToList();
            return View(values);
         
        }

        public async Task< IActionResult> MyApprovalReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.NameSurname;
            ViewBag.v = "Onay Bekleyen Rezervasyonunuz Bulunamadı!";

            var values = _reservationService.TGetList().Where(x=>x.AppUserID==user.Id && x.Status=="Onay Bekliyor").ToList();
         
            
                return View(values);
            
           
             
               
            
         
           
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            var values = _destinationService.TGetList();
            List<SelectListItem> destination = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.City,
                                                   Value = x.City
                                               }).ToList();
            ViewBag.destination = destination;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserID= user.Id;
            p.Status = "Onay Bekliyor";
            _reservationService.TInsert(p);
            return RedirectToAction("MyCurrentReservation","Reservation", new { area = "Member" });
        }
    }
}
