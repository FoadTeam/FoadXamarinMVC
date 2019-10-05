using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;

namespace XamarinMVC.Areas.Admin.Controllers
{
    public class FactorsController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Factors
        public ActionResult Index(string strsearch)
        {
            var factors = db.Factors.Where(f => f.IsPay == true).OrderByDescending(f => f.PayDate).ToList();
            if (!string.IsNullOrEmpty(strsearch))
            {
                factors = factors.Where(u => u.User.Mobile.Contains(strsearch)).ToList();
            }
            return View(factors);
        }
        public ActionResult ShowDetails(int? id)
        {
            var details = db.FactorDetail.Where(d => d.FactorId == id).ToList();
            return View(details);
        }
        public ActionResult ShowAddress(int? id)
        {
            var addredd = db.Addresses.Find(id);
            return PartialView(addredd);
        }
    }
}