using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ParkWhere.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //These codes are to be split into another controller class
            String url = "http://www.nea.gov.sg/api/WebAPI?dataset=nowcast&keyref=781CF461BB6606AD4AF8F309C0CCE994AC81FD9664F88220";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                String content;
                using (readStream)
                {
                    content = readStream.ReadLine();
                    //ViewBag.Quote = content;
                }

                string[] tokens = content.Split(new [] { '<' + "area name=" + '"', '"' + " forecast=" + '"', '"' + " icon=" + '"' }, StringSplitOptions.None);

                //For testing 
                string myArea = "YISHUN";
                int i = 0;
                while (!tokens[i].Equals(myArea))
                {
                    i++;
                }
                string weatherForecast = "My current location: " + tokens[i] + " | Forecast: " + tokens[i + 1];
                ViewBag.Quote = weatherForecast;
            }
            catch (WebException we)
            {
                Stream receiveStream = we.Response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                System.Diagnostics.Debug.WriteLine("Error Encountered - ");
                System.Diagnostics.Debug.WriteLine(readStream.ReadToEnd());
            }
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