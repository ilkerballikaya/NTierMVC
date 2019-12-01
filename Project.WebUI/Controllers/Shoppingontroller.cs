using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.WebUI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{

    [MemberAuth]
    public class Shoppingontroller : Controller
    {
        ProductRepository pRep;
        public Shoppingontroller()
        {
            pRep = new ProductRepository();
        }
        // GET: Shoppingontroller
        public ActionResult ProductList()
        {
            return View(pRep.GetActives());
        }
    }
}