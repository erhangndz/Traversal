﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class MailController : Controller
    {

        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal Admin", "traversalnoreply@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress(p.ReceiverName, p.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody = p.Body;
           
            mimeMessage.Body=bodyBuilder.ToMessageBody();
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
