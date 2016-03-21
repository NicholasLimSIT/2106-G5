using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkWhere.Models;

namespace ParkWhere.DAL
{
    public class PetrolStationGateway :DataGateway<PetrolStation>
    {
        public List<string[]> GetAllPetrolStation()
        {
            IEnumerable<PetrolStation> PetrolStations;
            List<string[]> PetrolStationList;

            PetrolStations = SelectAll();
            PetrolStationList = new List<string[]>();

            foreach (var item in PetrolStations)
            {
                string[] listString = new string[4];
                listString[0] = item.petrolStationName;
                listString[1] = item.latitude.ToString();
                listString[2] = item.longitude.ToString();
                listString[3] = item.Id.ToString();
                PetrolStationList.Add(listString);
            }

            return PetrolStationList;
        }
    }
}