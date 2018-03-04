using CommunityWeb.Models;
using CommunityWeb.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web;
using System.IO;

namespace CommunityWeb.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionsController()
        {
            // Create a database instance for accessing
            _context = new ApplicationDbContext();
        }

        // GET: questions/ask
        // An action goes to "Ask a question" view
        [Authorize]
        public ActionResult Ask()
        {
            // "ask a question" view contains input fields for question and a list of topics to choose
            // so we need to load all topics to the form through this viewmodel
            var questionViewModel = new QuestionViewModel
            {
                Topics = _context.Topics.ToList()
            };

            // Go to view "Ask" and pass data in questionViewModel to that view
            return View(questionViewModel);
        }

        // This action is called when user click to post a question
        [HttpPost]
        public ActionResult Ask(QuestionViewModel questionViewModel)
        {
            string title = string.Empty, desc = string.Empty, tps = string.Empty, img = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any() ||
                System.Web.HttpContext.Current.Request.Form.AllKeys.Any())
            {

                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                if (pic != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Uploads"), pic.FileName);
                    pic.SaveAs(path);
                    img = pic.FileName;
                }
                else
                {
                    img = "";
                }
                title = System.Web.HttpContext.Current.Request.Form["Title"];
                desc = System.Web.HttpContext.Current.Request.Form["Description"];
                tps = System.Web.HttpContext.Current.Request.Form["Topics"];
            }

            var tt = tps.Split(',');

            // Create a question object
            var question = new Question
            {
                UserId = User.Identity.GetUserId(),
                Title = title,
                Description = desc,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ImageUrls = img,
            };

            // Add question object into Questions DBSet
            _context.Questions.Add(question);
            // Save question object(s) in Questions DBSet into the database
            _context.SaveChanges();

            // Get id of question just added
            var questionId = _context.Questions.OrderByDescending(q => q.Id).First().Id;

            var topics = _context.Topics.Where(t => tt.Contains(t.Name)).ToList();

            foreach(var topic in topics)
            {
                var questionTopicDetail = new QuestionTopicDetail
                {
                    QuestionId = questionId,
                    Topic = topic
                };
                _context.QuestionTopicDetails.Add(questionTopicDetail);
            }

            _context.SaveChanges();

            return Json(Url.Action("Index", "Home"));
        }

        // View questions by QuestionID
        public ActionResult View(int id)
        {
            var question = _context.Questions.Include(q => q.User).Single(q => q.Id == id);
            var topics = _context.QuestionTopicDetails.Include(t => t.Topic).Where(q => q.QuestionId == id).ToList();
            var answers = _context.Answers.Where(a => a.QuestionId == id).Include(a => a.User).ToList();
            var answerViewModel = new AnswerViewModel
            {
                Question = question,
                Answers = answers,
                Topics = topics
            };
            return View(answerViewModel);
        }

    }
}