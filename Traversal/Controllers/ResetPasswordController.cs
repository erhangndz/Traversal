using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Drawing;
using Traversal.Models;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class ResetPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ResetPasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Mail);
            string passwordResetToken= await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "ResetPassword", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "erhangndz@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("Üye", model.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Şifrenizi Sıfırlamak için aşağıdaki linke tıklayabilirsiniz." + "    " + passwordResetTokenLink;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Şifre Değişiklik Talebi";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("erhangndz@gmail.com", "yebhkmrmskljbthp");
            client.Send(mimeMessage);
            client.Disconnect(true);

            
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid,string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            string userid = TempData["userid"].ToString();
            string token = TempData["token"].ToString();
            if(userid==null || token==null)
            {
                //hata mesajı
            }
            var user = await _userManager.FindByIdAsync(userid);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
            if (result.Succeeded && ModelState.IsValid)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();
		}



	}
}
