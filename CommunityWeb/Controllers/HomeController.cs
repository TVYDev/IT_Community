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
        //private ApplicationUserManager _userManager;
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUser USER;
        private ApplicationDbContext _contextDb;

        public HomeController()
        {
            //USER = new ApplicationUser();
            _contextDb = new ApplicationDbContext();
        }

        //public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}

        public string UserPhotos()
        {
            
            return "";
        }

        public ActionResult Index()
        {
            //if (Session["user"] != null)
            //{
            //    ViewBag.test = "Null";
            //    return View();
            //}
            //else
            //{
            //            var user = _userManager.FindById(SignInManager
            //.AuthenticationManager
            //.AuthenticationResponseGrant.Identity.GetUserId());

            //            if (user.ImgUrl == null)
            //                ViewBag.url = "#";
            //            else
            //                ViewBag.ImageUrl = user.ImgUrl;
            //            //    var id = User.Identity.GetUserId();
            //            //    ViewBag.url = User.Identity.GetUserId();
            //            //    ViewBag.test = "Not Null";
            //            //    return View();
            //            //}TempData["ImageUrl"]
            //            //ViewBag.ImageUrl = TempData["ImageUrl"];
            if (User.Identity.IsAuthenticated)
            {
                String Id = User.Identity.GetUserId();
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                //var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();
                //var Users = _userManager.FindById(Id.ToString());
                var comp = _contextDb.Users.Where(i => i.Id == Id).First();
                if (comp.ImgUrl == null)
                {
                    ViewBag.ImageUrl = "588px-rupp_logo.png";
                }
                else
                {
                    string url = comp.ImgUrl.Remove(0, 12);
                    ViewBag.ImageUrl = url;
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

    }
}