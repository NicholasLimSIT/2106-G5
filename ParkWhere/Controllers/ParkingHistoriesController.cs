using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkWhere.DAL;
using ParkWhere.Models;

namespace ParkWhere.Controllers
{
    public class ParkingHistoriesController : GeneralController<ParkingHistory>
    {
        private ParkWhereDBEntities db = new ParkWhereDBEntities();

        // GET: ParkingHistories
        public ActionResult Index()
        {
            var parkingHistories = db.ParkingHistories.Include(p => p.Carpark);
            return View(parkingHistories.ToList());
        }

        

        // GET: ParkingHistories/Create
        public ActionResult Create()
        {
            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo");
            return View();
        }

        // POST: ParkingHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "parkingHistoryId,carparkId,username,date,description")] ParkingHistory parkingHistory)
        {
            if (ModelState.IsValid)
            {
                db.ParkingHistories.Add(parkingHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo", parkingHistory.carparkId);
            return View(parkingHistory);
        }

        // GET: ParkingHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingHistory parkingHistory = db.ParkingHistories.Find(id);
            if (parkingHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo", parkingHistory.carparkId);
            return View(parkingHistory);
        }

        // POST: ParkingHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "parkingHistoryId,carparkId,username,date,description")] ParkingHistory parkingHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.carparkId = new SelectList(db.Carparks, "id", "carparkNo", parkingHistory.carparkId);
            return View(parkingHistory);
        }

        // GET: ParkingHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingHistory parkingHistory = db.ParkingHistories.Find(id);
            if (parkingHistory == null)
            {
                return HttpNotFound();
            }
            return View(parkingHistory);
        }

        // POST: ParkingHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingHistory parkingHistory = db.ParkingHistories.Find(id);
            db.ParkingHistories.Remove(parkingHistory);
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
