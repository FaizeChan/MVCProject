using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Models
{
    public class DreamLocationsController : Controller
    {
        private MVCProjectContext db = new MVCProjectContext();

        // GET: DreamLocations
        public ActionResult Index()
        {
            var dreamLocations = db.DreamLocations.Include(d => d.List);
            return View(dreamLocations.ToList());
        }

        // GET: DreamLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DreamLocation dreamLocation = db.DreamLocations.Find(id);
            if (dreamLocation == null)
            {
                return HttpNotFound();
            }
            return View(dreamLocation);
        }

        // GET: DreamLocations/Create
        public ActionResult Create()
        {
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName");
            return View();
        }

        // POST: DreamLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DreamLocationID,ItemName,DateFounded,Details,ListID")] DreamLocation dreamLocation)
        {
            if (ModelState.IsValid)
            {
                db.DreamLocations.Add(dreamLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", dreamLocation.ListID);
            return View(dreamLocation);
        }

        // GET: DreamLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DreamLocation dreamLocation = db.DreamLocations.Find(id);
            if (dreamLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", dreamLocation.ListID);
            return View(dreamLocation);
        }

        // POST: DreamLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DreamLocationID,ItemName,DateFounded,Details,ListID")] DreamLocation dreamLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dreamLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", dreamLocation.ListID);
            return View(dreamLocation);
        }

        // GET: DreamLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DreamLocation dreamLocation = db.DreamLocations.Find(id);
            if (dreamLocation == null)
            {
                return HttpNotFound();
            }
            return View(dreamLocation);
        }

        // POST: DreamLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DreamLocation dreamLocation = db.DreamLocations.Find(id);
            db.DreamLocations.Remove(dreamLocation);
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
