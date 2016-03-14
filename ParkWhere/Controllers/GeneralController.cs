using ParkWhere.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ParkWhere.Controllers
{
    public class GeneralController<T> : Controller where T : class
    {
        internal IDataGateway<T> dataGateway;
        // GET: General
        virtual public ActionResult Index(int? id)
        {
            return View(dataGateway.SelectAll());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T obj = dataGateway.SelectById(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }
    }
}