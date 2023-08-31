using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetAll();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.TGetByID(id);
            values.Status = false;
            _commentService.TUpdate(values);
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmComment(int id)
        {
            var values = _commentService.TGetByID(id);
            values.Status = true;
            _commentService.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}
