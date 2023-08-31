using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Destination
{
    public class _DestinationDetails:ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public _DestinationDetails(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                ViewBag.image = user.Image;
                ViewBag.name = user.NameSurname;
                ViewBag.Id = id;
                var values = _destinationService.TGetAll().Where(x => x.DestinationID == id).FirstOrDefault();

                return View(values);
            }
            else
            {
                ViewBag.Id = id;
                var values = _destinationService.TGetAll().Where(x => x.DestinationID == id).FirstOrDefault();

                return View(values);
            }
           
        }
    }
}
