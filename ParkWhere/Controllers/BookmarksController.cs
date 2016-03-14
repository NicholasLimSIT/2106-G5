using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ParkWhere.Models;

namespace ParkWhere.Controllers
{
    public class BookmarksController : GeneralController<Bookmark>
    {
        private ParkWhereDBEntities db = new ParkWhereDBEntities();

        // GET: Bookmarks/Create
        public ActionResult Create()
        {
            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo");
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,carparkId,date,username")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                db.Bookmarks.Add(bookmark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo", bookmark.carparkId);
            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo", bookmark.carparkId);
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,carparkId,date,username")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookmark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo", bookmark.carparkId);
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = db.Bookmarks.Find(id);
            db.Bookmarks.Remove(bookmark);
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
