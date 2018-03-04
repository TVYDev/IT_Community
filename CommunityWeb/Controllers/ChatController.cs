using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityWeb.ViewModels;
using CommunityWeb.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace CommunityWeb.Controllers
{
    public class ChatController : Controller
    {

         private ApplicationDbContext _contextDb;




        public ChatController()
        {
            //USER = new ApplicationUser();
            _contextDb = new ApplicationDbContext();
        }

        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Query()
        {
            var chats = _contextDb.Chats.Include(c => c.User).ToList();
            return View("Chat", chats);
        }

        [HttpPost]
        public ActionResult Save(ChatViewModel chatviewModel)
        {

            //var answer = new Answer
            //{
            //    UserId = User.Identity.GetUserId(),
            //    QuestionId = QuestionId,
            //    Description = AnswerDescription,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now,
            //    ImageUrls = "ImageUrls",
            //    IsAccepted = false
            //};
            //_context.Answers.Add(answer);
            //_context.SaveChanges();

            //var user = _contextDb.Users.Find(User.Identity.GetUserId());
            var Chat = new Chat
            {

                //Title: $('.qTitle').val(),
                //      Description: $('.qDesc').val(),
                //      SelectedTopics: topics

                UserId = User.Identity.GetUserId(),
                Body = chatviewModel.body,
                SentDate = DateTime.Now,
                Status = 0
            };
            try
            {

            _contextDb.Chats.Add(Chat);
            _contextDb.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

            return null;
        }

        [Authorize]
        public ActionResult Chat()
        {
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var user = _contextDb.Users.Find(User.Identity.GetUserId());

            //var username = '"' + user.UserName + '"';
            //ViewBag.userName = username;
            ViewBag.userName = user.UserName;


            return View(_contextDb.Chats.Include(c => c.User).ToList());
            

        }
    }
}