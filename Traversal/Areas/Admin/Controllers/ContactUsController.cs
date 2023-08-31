using BusinessLayer.Abstract;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
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
        [HttpGet]
        public IActionResult ContactUsDetails(int id)
        {
            var values = _contactUsService.TGetByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult ReplyMessage(int id)
        {
            var values = _contactUsService.TGetList().Where(x => x.ContactUsID == id).FirstOrDefault();
            ViewBag.mail = values.Mail;
            ViewBag.name = values.Name;
            ViewBag.content = values.MessageBody;
            ViewBag.subject ="Yanıt : " + values.Subject;
            return View();
        }
        [HttpPost]
        public IActionResult ReplyMessage(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal Admin", "traversalnoreply@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress(p.ReceiverName, p.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = p.Body;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = p.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalnoreply@gmail.com", "idekglamodhssdrb");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }

	}
}
