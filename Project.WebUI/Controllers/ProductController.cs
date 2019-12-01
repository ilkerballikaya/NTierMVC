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
    public class ProductController : Controller
    {
        ProductRepository pRep;
        CategoryRepository cRep;
        public ProductController()
        {
            pRep = new ProductRepository();
            cRep = new CategoryRepository();
        }
        // GET: Product
        public ActionResult ProductList()
        {
            return View(pRep.GetAll());
        }

        public ActionResult AddProduct()
        {
            ViewBag.CategoryList = cRep.GetActives();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryList = cRep.GetActives();
                return View();
            }
            pRep.Add(product);
            return RedirectToAction("ProductList");
        }
        public ActionResult UpdateProduct(int id)
        {
            ViewBag.CategoryList = cRep.GetActives();
            return View(pRep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryList = cRep.GetActives();
                return View();
            }
            pRep.Update(product);
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            pRep.Delete(pRep.Find(id));
            return RedirectToAction("ProductList");
        }
    }
}