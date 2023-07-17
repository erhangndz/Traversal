using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentcount = _commentService.TGetList().Where(x=>x.DestinationID==id).Count();
            var values= _commentService.TGetList().Where(x=>x.DestinationID==id).ToList();
            return View(values);
        }
    }
}
