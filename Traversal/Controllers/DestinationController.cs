using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService destinationService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.Id = id;
            var values = _destinationService.TGetByID(id);

            return View(values);
        }

       

        [HttpGet]
        public async Task<PartialViewResult> AddComment()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
           
            ViewBag.image=user.Image;
            ViewBag.name = user.NameSurname;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment p, int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.NameSurname;
            p.AppUserID= user.Id;
            p.Status = true;
            p.CommentDate = DateTime.Now;
            p.Image= user.Image;
         
            _commentService.TInsert(p);
          
        
            return RedirectToAction("Index");
        }
    }
}
