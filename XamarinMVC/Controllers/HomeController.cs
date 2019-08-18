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
    }
}