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
    public class CarparksController : Controller
    {
        private ParkWhereDBEntities db = new ParkWhereDBEntities();
        private CarparkGateway carparkGateway = new CarparkGateway();
        Carpark model = new Carpark();
        // GET: Carparks
        public ActionResult Index()
        {
           return View(carparkGateway.SelectAll());
        }
        [HttpPost]
        public ActionResult Index(string addResults)
        {
            return View(carparkGateway.searchCarpark(addResults));
        }

        // GET: Carparks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carpark carpark = carparkGateway.SelectById(id);
            if (carpark == null)
            {
                return HttpNotFound();
            }
            return View(carpark);
        }

        // GET: Carparks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carparks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,carparkNo,address,x_coord,y_coord,carparkType,typeOfparking,shortTermparking,freeParking,nightParking,parkAndrideScheme,adhocParking")] Carpark carpark)
        {
            if (ModelState.IsValid)
            {
                carparkGateway.Insert(carpark);
                return RedirectToAction("Index");
            }

            return View(carpark);
        }

        // GET: Carparks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carpark carpark = carparkGateway.SelectById(id);
            if (carpark == null)
            {
                return HttpNotFound();
            }
            return View(carpark);
        }

        // POST: Carparks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,carparkNo,address,x_coord,y_coord,carparkType,typeOfparking,shortTermparking,freeParking,nightParking,parkAndrideScheme,adhocParking")] Carpark carpark)
        {
            if (ModelState.IsValid)
            {
                carparkGateway.Update(carpark);
                carparkGateway.Save();
                return RedirectToAction("Index");
            }
            return View(carpark);
        }

        // GET: Carparks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carpark carpark = carparkGateway.SelectById(id);
            if (carpark == null)
            {
                return HttpNotFound();
            }
            return View(carpark);
        }

        // POST: Carparks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carpark carpark = carparkGateway.SelectById(id);
            carparkGateway.Delete(id);
            carparkGateway.Save();
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
