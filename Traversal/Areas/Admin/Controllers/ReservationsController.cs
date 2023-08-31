using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            DateTime today = DateTime.Today;
            var reservationsToUpdate = _reservationService.TGetList()
                     .Where(x => x.ReservationDate < today && x.Status != "Geçmiş Rezervasyon")
                     .ToList();
            foreach (var reservation in reservationsToUpdate)
            {
                reservation.Status = "Geçmiş Rezervasyon";
                _reservationService.TUpdate(reservation);
            }
            var list = _reservationService.TGetAll();
            return View(list);
        }

        public IActionResult ConfirmReservation(int id)
        {
            var values = _reservationService.TGetByID(id);
            values.Status = "Onaylandı";
            _reservationService.TUpdate(values);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteReservation(int id)
        {
            var values = _reservationService.TGetByID(id);
            _reservationService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
