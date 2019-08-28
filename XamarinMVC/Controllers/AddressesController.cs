using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;

namespace XamarinMVC.Controllers
{
    [Authorize]
    public class AddressesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Addresses
        public ActionResult Index()
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            if (user.IsActive == false)
            {
                return RedirectToAction("Activate", "Account");
            }
            else
            {
                var addresses = db.Addresses.Include(a => a.User);
                return View(addresses.ToList());
            }
           
        }


        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.Mobile==User.Identity.Name), "Id", "UserName");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,AddressText,AddressState,AddressCity,AddressPostalCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users.Where(u => u.Mobile == User.Identity.Name), "Id", "UserName", address.UserId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.Mobile == User.Identity.Name), "Id", "UserName", address.UserId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,AddressText,AddressState,AddressCity,AddressPostalCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.Mobile == User.Identity.Name), "Id", "UserName", address.UserId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
