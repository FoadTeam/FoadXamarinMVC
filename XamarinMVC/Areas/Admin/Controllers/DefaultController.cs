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

        public ActionResult CallSetting()
        {
            var setting = db.Settings.FirstOrDefault();
            return View(setting);
        }

        [HttpPost]
        public ActionResult CallSetting(Setting setting)
        {
            if (ModelState.IsValid)
            {
                var set = db.Settings.FirstOrDefault();
                set.Address = setting.Address;
                set.Fax = setting.Fax;
                set.Mobile = setting.Mobile;
                set.Tell = setting.Tell;

                db.SaveChanges();

            }
            return View(setting);
        }

        public ActionResult SMSEmailSetting()
        {
            var setting = db.Settings.FirstOrDefault();
            return View(setting);
        }

        [HttpPost]
        public ActionResult SMSEmailSetting(Setting setting)
        {
            if (ModelState.IsValid)
            {
                var set = db.Settings.FirstOrDefault();
                set.EmailHost = setting.EmailHost;
                set.EmailPassword = setting.EmailPassword;
                set.EmailPort = setting.EmailPort;
                set.EmailSSl = setting.EmailSSl;
                set.EmailUser = setting.EmailUser;
                set.FactorIsSend = setting.FactorIsSend;
                set.PayIsSend = setting.PayIsSend;
                set.SmsPassword = setting.SmsPassword;
                set.SmsSender = setting.SmsSender;
                set.SmsUser = setting.SmsUser;
                db.SaveChanges();

            }
            return View(setting);
        }

    }
}