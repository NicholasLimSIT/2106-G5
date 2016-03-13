using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ParkWhere.Services;

namespace ParkWhere.Controllers
{
    public class HomeController : Controller
    {
        WeatherGateway weatherGateway = new WeatherGateway();

        public ActionResult Index()
        {
            ViewBag.Quote = weatherGateway.GetCurrentWeather("ANG MO KIO");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}