using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;
using System.Web.Security;

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
            if (user.IsActive == false)
            {
                return RedirectToAction("Activate", "Account");
            }
            else
            {
                return View();
            }

        }
        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {
            string hashpass = FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
            var user = db.users.FirstOrDefault(u => u.Mobile == User.Identity.Name && u.Password == hashpass);
            if (user != null)
            {
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                db.SaveChanges();
                if (user.Role.RoleName == "Admin")
                {
                    return Redirect("/Admin/Default");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ModelState.AddModelError("oldPassword", XamarinMVC.App_GlobalResources.Errors.OldPasswordIsIncurrect);
            }
            return View();
        }
    }
}