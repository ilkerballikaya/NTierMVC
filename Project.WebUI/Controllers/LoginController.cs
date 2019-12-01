using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    public class LoginController : Controller
    {
        AppUserRepository appUserRep;
        public LoginController()
        {
            appUserRep = new AppUserRepository();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            if (appUserRep.Any(x => x.UserName == appUser.UserName && x.Password == appUser.Password))
            {
                AppUser user = appUserRep.FirstOrDefault(x=>x.UserName==appUser.UserName && x.Password == appUser.Password);
                if (user.Role == MODEL.Enums.UserRoles.Admin)
                {
                    Session["Admin"] = user;
                    return RedirectToAction("CategoryList", "Category");
                }
                else if(user.Role == MODEL.Enums.UserRoles.Member)
                {
                    Session["Member"] = user;
                    return RedirectToAction("ProductList", "Shooping");
                }
            }
            ViewBag.KullaniciYok = "Kullanici Bulunamadi";
            return View();
        }
    }
}