using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
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
        public async Task<IActionResult> DestinationDetails(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                ViewBag.image = user.Image;
                ViewBag.name = user.NameSurname;
                ViewBag.Id = id;
                var values = _destinationService.TGetAll().Where(x=>x.DestinationID==id).FirstOrDefault();

                return View(values);
            }
            else
            {
                ViewBag.Id = id;
                var values = _destinationService.TGetAll().Where(x => x.DestinationID == id).FirstOrDefault();

                return View(values);
            }
            
            
        }

       

        [HttpGet]
        public async Task<PartialViewResult> AddComment()
        {

            
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment p, int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.NameSurname;
            p.AppUserID= user.Id;
            p.Status = false;
            p.CommentDate = DateTime.Now;
            p.Image= user.Image;
         
            _commentService.TInsert(p);


            return NoContent();
        }
    }
}
