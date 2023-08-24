using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public _CommentList(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.image = user.Image;
            
            ViewBag.commentcount = _commentService.TGetList().Where(x=>x.DestinationID==id).Count();
            var values= _commentService.TGetAll().Where(x=>x.DestinationID==id & x.Status==true).ToList();
           
            return View(values);
        }
    }
}
