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
    public class CarparksController : GeneralController<Carpark>
    {
        public CarparksController() {
            dataGateway = new CarparkGateway();
        }

        //public override ActionResult Index(int? id)
        //{
        //    ViewBag.List = (((CarparkGateway)dataGateway).GetAllCarparks());
        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(string value1, string value2)
        {
            if (Session["searchResult"] == null)
            {
                ViewBag.List = ((CarparkGateway)dataGateway).FilterByType(value1, value2);
                return View();
            }
            else {
                string searchResult = Session["searchResult"].ToString();
                ViewBag.List = ((CarparkGateway)dataGateway).FilterAddressByType(searchResult, value1, value2);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Index(string addResults)
        {
            Session["searchResult"] = addResults;
            ViewBag.List = ((CarparkGateway)dataGateway).searchCarpark(addResults);
            return View();
        }

    }

}
