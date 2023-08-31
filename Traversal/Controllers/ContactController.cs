using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office.CustomUI;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {

        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {

            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public PartialViewResult ContactForm()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult ContactForm(SendMessageDto p)
        {
            if(ModelState.IsValid)
            {
                

                _contactUsService.TInsert(new ContactUs
                {
                    Mail = p.Mail,
                    Name = p.Name,
                    MessageBody = p.MessageBody,
                    Subject = p.Subject,
                    MessageDate = DateTime.Now,
                    MessageStatus = true
                });
                return NoContent();
            }
            return NoContent();
            
        }
    }
}
