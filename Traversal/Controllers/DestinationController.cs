using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ICommentService _commentService;

        public DestinationController(IDestinationService destinationService, ICommentService commentService)
        {
            _destinationService = destinationService;
            _commentService = commentService;
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
        public PartialViewResult AddComment()
        {
           

            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p, int id)
        {
            p.Status = true;
            p.CommentDate= DateTime.Parse( DateTime.Now.ToShortDateString());
         
            _commentService.TInsert(p);
          
        
            return RedirectToAction("Index");
        }
    }
}
