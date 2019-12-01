using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using Project.WebUI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    [AdminAuth]
    public class UserController : Controller
    {
        AppUserRepository userRep;
        ProfileRepository profileRep; 
        public UserController()
        {
            userRep = new AppUserRepository();
            profileRep = new ProfileRepository();
        }

        public ActionResult UserList()
        {
            return View(userRep.GetAll());
        }

        // GET: User
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(AppUser appUser)
        {
            userRep.Add(appUser);
            return RedirectToAction("UserList", "User");
        }

        public ActionResult UpdateUser(int id)
        {
            return View(userRep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateUser(AppUser appUser)
        {
            userRep.Update(appUser);
            return RedirectToAction("UserList", "User");
        }

        public ActionResult DeleteUser(int id)
        {
            userRep.Delete(userRep.Find(id));
            return RedirectToAction("UserList", "User");
        }

        public ActionResult AddProfile(int id)
        {
            ViewBag.UserName = userRep.Find(id).UserName;
            return View();
        }

        [HttpPost]
        public ActionResult AddProfile(AppUserProfile appUserProfile)
        {
            profileRep.Add(appUserProfile);
            return RedirectToAction("UserList", "User");
        }

        public ActionResult UpdateProfile(int id)
        {
            return View(profileRep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateProfile(AppUserProfile appUserProfile)
        {
            profileRep.Update(appUserProfile);
            return RedirectToAction("UserList", "User");
        }


    }
}