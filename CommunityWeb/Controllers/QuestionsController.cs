using CommunityWeb.Models;
using CommunityWeb.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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
            // Create a question object
            var question = new Question
            {
                UserId = User.Identity.GetUserId(),
                Title = questionViewModel.Title,
                Description = questionViewModel.Description,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ImageUrls = "ImageUrls"
            };

            // Add question object into Questions DBSet
            _context.Questions.Add(question);
            // Save question object(s) in Questions DBSet into the database
            _context.SaveChanges();

            // Get id of question just added
            var questionId = _context.Questions.OrderByDescending(q => q.Id).First().Id;

            var questionTopicDetail = new QuestionTopicDetail
            {
                QuestionId = questionId,
                TopicId = questionViewModel.TopicId
            };

            _context.QuestionTopicDetails.Add(questionTopicDetail);
            _context.SaveChanges();

            return Content("Added successfully");
        }

        // View questions by QuestionID
        public ActionResult View(int id = 4)
        {
            var question = _context.Questions.Include(q => q.User).Single(q => q.Id == id);
            var answers = _context.Answers.Where(a => a.QuestionId == id).Include(a => a.User).ToList();
            var answerViewModel = new AnswerViewModel
            {
                Question = question,
                Answers = answers
            };
            return View(answerViewModel);
        }

    }
}