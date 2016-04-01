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
        public static List<string[]> CurrentCorrList;
        public ActionResult Index()
        {
            ViewBag.Weather = weatherGateway.GetCurrentWeather("ANG MO KIO");
            return View();
        }

        public ActionResult About()
        {
          
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void SaveViewBag(String Lat, String Lng)
        {
            CurrentCorrList = new List<string[]>();
            string[] listString = new string[2];
            listString[0] = Lat;
            listString[1] = Lng;
            CurrentCorrList.Add(listString);
           
        }
    }
}