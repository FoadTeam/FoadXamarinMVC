using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;

namespace XamarinMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Profile
        public ActionResult Index()
        {
            var user = db.users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            if (user.IsActive==false)
            {
                return RedirectToAction("Activate", "Account");
            }
            else
            {
                return View();
            }
            
        }
    }
}