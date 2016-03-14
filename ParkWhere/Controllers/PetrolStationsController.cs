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
    public class PetrolStationsController : GeneralController<PetrolStation>
    {
        public PetrolStationsController()
        {
            dataGateway = new PetrolStationGateway();
        }
    } 
}
