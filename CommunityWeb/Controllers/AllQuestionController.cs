using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityWeb.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace CommunityWeb.Controllers
{
    public class AllQuestionController : Controller
    {
        private ApplicationDbContext _context;

        public AllQuestionController()
        {
            // Create a database instance for accessing
            _context = new ApplicationDbContext();
        }

        // GET: AllQuestion
        public ActionResult AllQuestion()
        {

            return View(_context.Questions.OrderBy(q => q.UpdatedDate).ToList());
            //return View(_context.QuestionTopicDetails
            //    .Include(a => a.Question)
            //    .Include(a => a.Topic)
            //    .GroupBy(q => q.QuestionId)
            //    .ToList());
        }

        public ActionResult SearchText(string search)
        {
            var data = _context.Questions.Where(question => question.Title.Contains(search)).OrderBy(q => q.UpdatedDate).ToList();
            return Json(data);
        }
    
        public ActionResult LimitPage(int limit)
        {
            var data = _context.Questions.Skip(limit)
                .ToList();
            return Json(data);
            //return View("AllQuestion", data);
        }
        public ActionResult getOffset(int offset)
        {
            var data = _context.Questions.OrderBy(p => p.UpdatedDate).Skip(offset).ToList();
            return Json(data);
        }
    }
}