using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
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
            
            
            ViewBag.commentcount = _commentService.TGetList().Where(x=>x.DestinationID==id & x.Status==true).Count();
            var values= _commentService.TGetAll().Where(x=>x.DestinationID==id & x.Status==true).ToList();
           
            return View(values);
        }
    }
}
