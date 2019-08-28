using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;
using System.Web.Security;

namespace XamarinMVC.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Users
        public ActionResult Index(string strsearch)
        {
            var users = db.Users.Include(u => u.Role).ToList();
            if (!string.IsNullOrEmpty(strsearch))
            {
                users = users.Where(u => u.Mobile.Contains(strsearch)).ToList();
            }
            return View(users.ToList());
        }
        public ActionResult ShowAddress(int? id)
        {
            var address = db.Addresses.Where(u => u.User.Id == id);
            return View(address);
        }


            // GET: Admin/Users/Create
            public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,UserName,Mobile,Password,Code,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(u => u.Mobile == user.Mobile))
                {
                    Random random = new Random();
                    int mycode = random.Next(100000, 999999);
                    Models.User usr = new User()
                    {
                        IsActive = user.IsActive,
                        RoleId = user.RoleId,
                        Mobile = user.Mobile,
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5"),
                        Code = mycode.ToString(),
                        UserName=user.UserName
                    };
                    db.Users.Add(usr);
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Mobile", XamarinMVC.App_GlobalResources.Errors.RepeatMobile);
                }
               
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,UserName,Mobile,Password,Code,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(u => u.Id != user.Id && u.Mobile == user.Mobile))
                {
                    var usr = db.Users.FirstOrDefault(u => u.Id == user.Id);
                    usr.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                    usr.Mobile = user.Mobile;
                    usr.RoleId = user.RoleId;
                    usr.IsActive = user.IsActive;

                    //db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Mobile", XamarinMVC.App_GlobalResources.Errors.RepeatMobile);
                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
