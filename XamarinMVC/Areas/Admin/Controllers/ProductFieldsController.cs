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
    public class ProductFieldsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/ProductFields
        public ActionResult Index(int? id)
        {
            var productFields = db.ProductFields.Where(p => p.ProductId == id).Include(p => p.Field).Include(p => p.Product);
            ViewBag.myId = id;
            TempData["ID"] = id;
            return View(productFields.ToList());
        }

       

        // GET: Admin/ProductFields/Create
        public ActionResult Create(int? id)
        {
            ViewBag.FieldId = new SelectList(db.Fields, "Id", "ENName","FAName");
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.Id == id).ToList(), "Id", "Name");
            return PartialView();
        }

        // POST: Admin/ProductFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,FieldId,ENFieldValue,FAFieldValue")] ProductField productField,int? id)
        {
            if (ModelState.IsValid)
            {
                db.ProductFields.Add(productField);
                db.SaveChanges();
                return Redirect("/Admin/ProductFields/Index/"+id);
            }

            ViewBag.FieldId = new SelectList(db.Fields, "Id", "ENName", "FAName", productField.FieldId);
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.Id == id).ToList(), "Id", "Name", productField.ProductId);
            return PartialView(productField);
        }

        // GET: Admin/ProductFields/Delete/5
        public ActionResult Delete(int? id)
        {
            ProductField productField = db.ProductFields.Find(id);
            db.ProductFields.Remove(productField);
            db.SaveChanges();
            return Redirect("/Admin/ProductFields/Index/" + TempData["ID"]);
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
