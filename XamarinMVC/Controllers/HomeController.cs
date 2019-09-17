using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;

namespace XamarinMVC.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            var menu = db.Menus.Where(u => u.NotShow == false).OrderBy(u => u.Order).ToList();
            return PartialView(menu);
        }
        public ActionResult ShowMenu(int? id)
        {
            var menu = db.Menus.Find(id);
            return View(menu);
        }
        public ActionResult Slider()
        {
            var slider = db.Sliders.Where(u => u.NotShow == false).OrderBy(u => u.Order).ToList();
            return PartialView(slider);
        }
        public ActionResult Brand()
        {
            var brand = db.Brands.Where(u => u.NotShow == false).OrderBy(u => u.Order).ToList();
            return PartialView(brand);
        }
        public ActionResult Group()
        {
            var Group = db.Groups.Where(u => u.NotShow == false).OrderBy(u => u.Order).ToList();
            return PartialView(Group);
        }

        public ActionResult LastProduct()
        {
            var product = db.Products.Where(u => u.NotShow == false).OrderByDescending(u => u.Id).Take(4).ToList();
            return PartialView(product);
        }

        [Route("Product/{id}/{title}")]
        public ActionResult Product(int? id,string title)
        {
            var product = db.Products.Find(id);
            product.Seen = +1;
            db.SaveChanges();
            return View(product);
        }

        public ActionResult Gallery(int? id)
        {
            var gallery = db.Galleries.Where(u => u.ProductId == id).ToList();
            return PartialView(gallery);
        }
    }
}