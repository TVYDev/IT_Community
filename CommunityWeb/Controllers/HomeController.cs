using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CommunityWeb.Models;

namespace CommunityWeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _contextDb;

        public HomeController()
        {
            _contextDb = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                String Id = User.Identity.GetUserId();
                var comp = _contextDb.Users.Where(i => i.Id == Id).First();
                TempData["UserName"] = comp.UserName;

                if (comp.ImgUrl == null)
                {
                    TempData["ImageUrl"] = "588px-rupp_logo.png";
                    TempData["ImageUrlkeep"] = "588px-rupp_logo.png";
                }
                else
                {
                    string url = comp.ImgUrl.Remove(0, 12);
                    TempData["ImageUrl"] = url;
                    TempData["ImageUrlkeep"] = url;
                }

                if (TempData["UserName"] != TempData["UserNameKeep"])
                {
                    TempData["UserNameKeep"] = comp.UserName;
                    TempData["UserName"] = comp.UserName;
                }
                else
                {
                    TempData["UserNameKeep"] = comp.UserName;
                    TempData["UserName"] = comp.UserName;
                }
            }
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}