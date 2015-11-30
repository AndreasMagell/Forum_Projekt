using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.DataContexts;
using Forum.Entities;

namespace Forum.Controllers
{
    public class ThreadsController : Controller
    {
        private ForumDbContext db = new ForumDbContext();

        // GET: Threads
        public ActionResult Index(int? id)
        {
            return View(db.Threads.ToList());
        }

        // GET: Threads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // GET: Threads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Threads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Title, int Category)
        {

            Categories category = db.Categories.First(cat => cat.Id == Category);


            if (category != null)
            {
                Thread Thread = new Thread() { Title= Title, Category = category };

                Thread.Date = DateTime.Now;
                db.Threads.Add(Thread);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Threads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // POST: Threads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Date,Category")] Thread thread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thread).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thread);
        }

        // GET: Threads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // POST: Threads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thread thread = db.Threads.Find(id);
            db.Threads.Remove(thread);
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

        public class ThreadDetailViewModel
        {
            public Thread Thread { get; set; }

            public Post NewPost { get; set; }
        }

        public ActionResult ViewThreadDetail(int id)
        {
            // load thread from database
            var thread = new Thread() { Id = id, Title = "ASP.Net MVC 5", Posts = new List<Post>() };
            // assign ThreadId of New Post
            var newPost = new Post() {Body = "", Thread = id };

            return View(new ThreadDetailViewModel() { Thread = thread, NewPost = newPost });
        }
    }
}
