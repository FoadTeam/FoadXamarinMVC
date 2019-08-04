using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;

namespace XamarinMVC.Areas.Admin.Controllers
{
    public class SocialsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Socials
        public ActionResult Index()
        {
            return View(db.Socials.ToList());
        }

       
        // GET: Admin/Socials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Socials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Icon,Link,NotShow,Order")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Socials.Add(social);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(social);
        }

        // GET: Admin/Socials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = db.Socials.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: Admin/Socials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Icon,Link,NotShow,Order")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(social);
        }

        // GET: Admin/Socials/Delete/5
        public ActionResult Delete(int? id)
        {
            Social social = db.Socials.Find(id);
            db.Socials.Remove(social);
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
