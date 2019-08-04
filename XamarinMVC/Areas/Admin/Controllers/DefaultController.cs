using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;

namespace XamarinMVC.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SiteSetting()
        {
            var setting = db.Settings.FirstOrDefault();
            return View(setting);
        }
        [HttpPost]
        public ActionResult SiteSetting(Setting setting)
        {
            var set = db.Settings.FirstOrDefault();
            set.Description = setting.Description;
            set.Key = setting.Key;
            set.Name = setting.Name;
            db.SaveChanges();
            return View(setting);
        }




    }
}