using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;
using System.Resources;

namespace XamarinMVC.Areas.Admin.Controllers
{
    public class MenusController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Menus
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: Admin/Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Admin/Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NameEN,NameFA,NotShow,Order,Des")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var readerIR = new ResXResourceReader(Server.MapPath("~/App_GlobalResources/Menu.fa-IR.resx"));
                    var nodeIR = readerIR.GetEnumerator();
                    var readerEN = new ResXResourceReader(Server.MapPath("~/App_GlobalResources/Menu.resx"));
                    var nodeEN = readerEN.GetEnumerator();
                    var writerIR = new ResXResourceWriter(Server.MapPath("~/App_GlobalResources/Menu.fa-IR.resx"));
                    var writerEN = new ResXResourceWriter(Server.MapPath("~/App_GlobalResources/Menu.resx"));
                    while (nodeIR.MoveNext())
                    {
                        writerIR.AddResource(nodeIR.Key.ToString(), nodeIR.Value.ToString());
                    }
                    
                    while (nodeEN.MoveNext())
                    {
                        writerEN.AddResource(nodeEN.Key.ToString(), nodeEN.Value.ToString());
                    }
                    var newNodeIR = new ResXDataNode(menu.Name, menu.NameFA);
                    writerIR.AddResource(newNodeIR);
                    writerIR.Generate();
                    writerIR.Close();
                    var newNodeEN = new ResXDataNode(menu.Name, menu.NameEN);
                    writerEN.AddResource(newNodeEN);
                    writerEN.Generate();
                    writerEN.Close();

                }
                catch (Exception)
                {

                    throw;
                }


                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Admin/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NameEN,NameFA,NotShow,Order,Des")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var readerIR = new ResXResourceReader(Server.MapPath("~/App_GlobalResources/Menu.fa-IR.resx"));
                    var nodeIR = readerIR.GetEnumerator();
                    var readerEN = new ResXResourceReader(Server.MapPath("~/App_GlobalResources/Menu.resx"));
                    var nodeEN = readerEN.GetEnumerator();
                    var writerIR = new ResXResourceWriter(Server.MapPath("~/App_GlobalResources/Menu.fa-IR.resx"));
                    var writerEN = new ResXResourceWriter(Server.MapPath("~/App_GlobalResources/Menu.resx"));
                    while (nodeIR.MoveNext())
                    {
                  
                        if (nodeIR.Entry.Key.ToString() == menu.Name)
                        {
                            var newNodeIR = new ResXDataNode(menu.Name, menu.NameFA);
                            writerIR.AddResource(newNodeIR);
                        }
                        else
                        {
                            writerIR.AddResource(nodeIR.Key.ToString(), nodeIR.Value.ToString());
                        }
                    }
                    
                    while (nodeEN.MoveNext())
                    {
                        if (nodeEN.Key.ToString() == menu.Name)
                        {
                            var newNodeEN = new ResXDataNode(menu.Name, menu.NameEN);
                            writerEN.AddResource(newNodeEN);
                        }
                        else
                        {
                        writerEN.AddResource(nodeEN.Key.ToString(), nodeEN.Value.ToString());
                        }

                    }
                    writerIR.Generate();
                    writerIR.Close();
                    writerEN.Generate();
                    writerEN.Close();

                }
                catch (Exception)
                {

                    throw;
                }


                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Admin/Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            
            
            Menu menu = db.Menus.Find(id);
            try
            {
                var readerIR = new ResXResourceReader(Server.MapPath("~/App_GlobalResources/Menu.fa-IR.resx"));
                var nodeIR = readerIR.GetEnumerator();
                var readerEN = new ResXResourceReader(Server.MapPath("~/App_GlobalResources/Menu.resx"));
                var nodeEN = readerEN.GetEnumerator();
                var writerIR = new ResXResourceWriter(Server.MapPath("~/App_GlobalResources/Menu.fa-IR.resx"));
                var writerEN = new ResXResourceWriter(Server.MapPath("~/App_GlobalResources/Menu.resx"));
                while (nodeIR.MoveNext())
                {

                    if (nodeIR.Entry.Key.ToString() != menu.Name)
                    {
                        writerIR.AddResource(nodeIR.Key.ToString(), nodeIR.Value.ToString());
                    }
                }

                while (nodeEN.MoveNext())
                {
                    if (nodeEN.Key.ToString() != menu.Name)
                    {
                        writerEN.AddResource(nodeEN.Key.ToString(), nodeEN.Value.ToString());
                    }
                }
                writerIR.Generate();
                writerIR.Close();
                writerEN.Generate();
                writerEN.Close();

            }
            catch (Exception)
            {

                throw;
            }

            db.Menus.Remove(menu);
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
