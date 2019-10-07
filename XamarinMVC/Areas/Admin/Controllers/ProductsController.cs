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
    public class ProductsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Products
        public ActionResult Index(string strsearch)
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.Group).ToList();
            if (!string.IsNullOrEmpty(strsearch))
            {
                products = products.Where(u => u.Name.Contains(strsearch) || u.Group.Name.Contains(strsearch) || u.Brand.Title.Contains(strsearch)).ToList();
            }
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Title");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupId,BrandId,Name,NameEN,NameFA,Image,Price,Description,Seen,Quantity,NotShow")] Product product,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    Random random = new Random();
                    string imgCode = random.Next(100000, 999999).ToString();
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/Product/") + imgCode + "-" + file.FileName);
                    product.Image = imgCode + "-" + file.FileName;
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Title", product.BrandId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", product.GroupId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Title", product.BrandId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", product.GroupId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupId,BrandId,Name,NameEN,NameFA,Image,Price,Description,Seen,Quantity,NotShow")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    Random random = new Random();
                    string imgCode = random.Next(100000, 999999).ToString();
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/Products/") + imgCode + "-" + file.FileName);
                    product.Image = imgCode + "-" + file.FileName;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Title", product.BrandId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", product.GroupId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowPrint()
        {
            return View();
        }
        public ActionResult LoadReport()
        {
            var product = db.Products.OrderByDescending(p => p.Quantity).Take(8).ToList();
            var R = new Stimulsoft.Report.StiReport();
            R.Load(Server.MapPath("/Reports/QtyReport.mrt"));
            R.Compile();
            R.RegBusinessObject("myData", product);

            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(R);
        }
        public ActionResult MyEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
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
