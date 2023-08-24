using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Contact
{
    public class _ContactInfo:ViewComponent
    {
        private readonly IContactService _contactService;

        public _ContactInfo(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.TGetList();
            return View(values);
        }
    }
}
