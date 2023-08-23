using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Context context = new Context();
            List<SelectListItem> id = (from x in context.Accounts.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.Name,
                                           Value = x.AccountID.ToString()
                                       }).ToList();

            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            Context context = new Context();
            List<SelectListItem> id = (from x in context.Accounts.ToList() select new SelectListItem
            {
                Text=x.Name,
                Value=x.AccountID.ToString()
            }).ToList();

            ViewBag.id = id;

            
            var valueSender = _accountService.TGetByID(model.SenderID);
            var valueReceiver = _accountService.TGetByID(model.ReceiverID);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<Account> modifiedAccount = new List<Account>()
            {
                valueSender,
                valueReceiver 
            };

            _accountService.TMultiUpdate(modifiedAccount);
            return NoContent();
        }
    }
}
