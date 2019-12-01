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
    public class CategoryController : Controller
    {
        CategoryRepository cRep;
        public CategoryController()
        {
            cRep = new CategoryRepository();
        }
        // GET: Category
        public ActionResult CategoryList()
        {
            return View(cRep.GetAll());
        }

        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            cRep.Add(category);
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            cRep.Delete(cRep.Find(id));
            return RedirectToAction("CategoryList");
        }

        public ActionResult UpdateCategory(int id)
        {
            return View(cRep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cRep.Update(category);
            return RedirectToAction("CategoryList");
        }



    }
}