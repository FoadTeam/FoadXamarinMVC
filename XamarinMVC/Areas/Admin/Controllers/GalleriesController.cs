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
    public class GalleriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Galleries
        public ActionResult Index(int? id)
        {
            var galleries = db.Galleries.Where(u => u.ProductId == id).Include(g => g.Product);
            ViewBag.myid = id;
            return View(galleries.ToList());
        }

       
        // GET: Admin/Galleries/Create
        public ActionResult Create(int? id)
        {
            ViewBag.ProductId = new SelectList(db.Products.Where(u => u.Id == id).ToList(), "Id", "Name");
            return PartialView();
        }

        // POST: Admin/Galleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,Image")] Gallery gallery, int? id,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    Random random = new Random();
                    string imgCode = random.Next(100000, 999999).ToString();
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/Gallery/") + imgCode + "-" + file.FileName);
                    gallery.Image = imgCode + "-" + file.FileName;
                }

                db.Galleries.Add(gallery);
                db.SaveChanges();
                return Redirect("/Admin/Galleries/Index/"+ id);
            }

            ViewBag.ProductId = new SelectList(db.Products.Where(u => u.Id == id).ToList(), "Id", "Name");
            return PartialView(gallery);
        }


        // GET: Admin/Galleries/Delete/5
        public ActionResult Delete(int? id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
            db.SaveChanges();
            return Redirect("/Admin/Galleries/Index/" + id);
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
