using CommunityWeb.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.Mvc;

namespace CommunityWeb.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext _context;

        public CommentsController()
        {
            // Create a database instance for accessing
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Comment(int QuestionId, int AnswerId, string CommentDescription)
        {
            var comment = new Comment
            {
                UserId = User.Identity.GetUserId(),
                AnswerId = AnswerId,
                Description = CommentDescription,
                CreatedDate = DateTime.Now
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("View", "Questions", new { id = QuestionId });
        }
    }
}