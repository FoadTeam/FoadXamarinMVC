using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;
using PagedList;

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
        public ActionResult ShowFields(int? id)
        {
            var fields = db.ProductFields.Where(u => u.ProductId == id).ToList();
            return PartialView(fields);
        }
        public ActionResult Filter(string StrSearch , int? page = 1)
        {
            var product = db.Products.Where(p => p.NotShow == false && (p.NameEN.Contains(StrSearch) || 
            p.NameFA.Contains(StrSearch) || p.Group.NameEN.Contains(StrSearch) || p.Group.NameFA.Contains(StrSearch) ||
            p.Brand.Title.Contains(StrSearch) || p.Description.Contains(StrSearch))).OrderByDescending(p => p.Id).ToList();
           
            return View(product.ToPagedList((int)page,16));
        }
    }
}