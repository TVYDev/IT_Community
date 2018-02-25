using CommunityWeb.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace CommunityWeb.Controllers
{
    public class AnswersController : Controller
    {
        private ApplicationDbContext _context;

        public AnswersController()
        {
            // Create a database instance for accessing
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public ActionResult Answer(int QuestionId, string AnswerDescription)
        {
            var answer = new Answer
            {
                UserId = User.Identity.GetUserId(),
                QuestionId = QuestionId,
                Description = AnswerDescription,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ImageUrls = "ImageUrls",
                IsAccepted = false
            };
            _context.Answers.Add(answer);
            _context.SaveChanges();
            return RedirectToAction("View","Questions", new { id = QuestionId });
        }
    }
}