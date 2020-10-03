using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Areas.Manager.Controllers
{
    public class TB_ProductController : Controller
    {
        private LOGINEntities1 db = new LOGINEntities1();

        // GET: Manager/TB_Product
        public ActionResult Index()
        {
            return View(db.TB_Product.ToList());
        }

        // GET: Manager/TB_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Product tB_Product = db.TB_Product.Find(id);
            if (tB_Product == null)
            {
                return HttpNotFound();
            }
            return View(tB_Product);
        }

        // GET: Manager/TB_Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/TB_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduct,Name_Product,Img_Product")] TB_Product tB_Product)
        {
            if (ModelState.IsValid)
            {
                db.TB_Product.Add(tB_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Product);
        }

        // GET: Manager/TB_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Product tB_Product = db.TB_Product.Find(id);
            if (tB_Product == null)
            {
                return HttpNotFound();
            }
            return View(tB_Product);
        }

        // POST: Manager/TB_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,Name_Product,Img_Product")] TB_Product tB_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Product);
        }

        // GET: Manager/TB_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Product tB_Product = db.TB_Product.Find(id);
            if (tB_Product == null)
            {
                return HttpNotFound();
            }
            return View(tB_Product);
        }

        // POST: Manager/TB_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Product tB_Product = db.TB_Product.Find(id);
            db.TB_Product.Remove(tB_Product);
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
