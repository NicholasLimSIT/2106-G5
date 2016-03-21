using System.Web.Mvc;
using ParkWhere.DAL;
using ParkWhere.Models;
using System.Net;

namespace ParkWhere.Controllers
{
    public class PetrolStationsController : GeneralController<PetrolStation>
    {
        public PetrolStationsController()
        {
            dataGateway = new PetrolStationGateway();
        }

        public override ActionResult Index(int? id)
        {
            ViewBag.List = ((PetrolStationGateway)dataGateway).GetAllPetrolStation();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string addResults)
        {

            ViewBag.List = ((PetrolStationGateway)dataGateway).searchPetrolStation(addResults);
            return View();
        }
        

    }
}
