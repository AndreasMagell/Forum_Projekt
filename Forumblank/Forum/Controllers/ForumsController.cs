using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.DataContexts;
using Forum.Models;

namespace Forum.Controllers
{
    public class ForumsController : Controller
    {
        private ForumDbContext db = new ForumDbContext();

        // GET: Forums
        public ActionResult Index()
        {
            return View(db.Forums.ToList());
        }

        // GET: Forums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forums forums = db.Forums.Find(id);
            if (forums == null)
            {
                return HttpNotFound();
            }
            return View(forums);
        }

        // GET: Forums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Category)
        {
            Categories category = db.Categories.First(cat => cat.Id == Category);

            if (category != null)
            {
                Forums forums = new Forums() { Category = category };

                db.Forums.Add(forums);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Forums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forums forums = db.Forums.Find(id);
            if (forums == null)
            {
                return HttpNotFound();
            }
            return View(forums);
        }

        // POST: Forums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category")] Forums forums)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forums).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forums);
        }

        // GET: Forums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forums forums = db.Forums.Find(id);
            if (forums == null)
            {
                return HttpNotFound();
            }
            return View(forums);
        }

        // POST: Forums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forums forums = db.Forums.Find(id);
            db.Forums.Remove(forums);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoriesDropDown()
        {
            return PartialView("_CategoriesDropDown", db.Categories.ToList());
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
