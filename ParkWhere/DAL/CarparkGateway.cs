using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ParkWhere.Models;
using ParkWhere.DAL;

namespace ParkWhere.DAL
{
    public class CarparkGateway : DataGateway<Carpark>
    {
       
        IEnumerable<Carpark> model;

        public CarparkGateway()
        {
            this.data = db.Set<Carpark>();
        }

        public List<string[]> GetAllCarparks()
        {
            IEnumerable<Carpark> Carparks;
            List<string[]> CarparkList;

            Carparks = SelectAll();
            CarparkList = new List<string[]>();

            foreach (var item in Carparks)
            {
                string[] listString = new string[7];
                listString[0] = item.id.ToString();
                listString[1] = item.carparkNo;
                listString[2] = item.address;
                listString[3] = item.carparkType;
                listString[4] = item.typeOfparking;
                listString[5] = item.x_coord.ToString();
                listString[6] = item.y_coord.ToString();
                CarparkList.Add(listString);
            }
            return CarparkList;
        }

        public IEnumerable<Carpark> searchCarpark(string address)
        {
            if (address== null)
            {
                model = data.SqlQuery("SELECT * From dbo.Carparks ").ToList();
                return model;
            }
            else
            {
                string str = address.Substring(0, 5);
                model = data.SqlQuery("SELECT * From dbo.Carparks WHERE address LIKE '%" + str + "%'").ToList();
                return model;
            }
        }
        public IEnumerable<Carpark> FilterAddressByType(string address,string parkingTyperesult, string carparkTyperesult)
        {
            
                string resultAddress = address.Substring(0, 5);
                model = data.SqlQuery("SELECT * From dbo.Carparks WHERE address LIKE '%" + resultAddress + "%' AND typeOfparking = '"+parkingTyperesult+"' AND carparkType = '"+carparkTyperesult+"'").ToList();
                return model;
            
        }
        public IEnumerable<Carpark> FilterByType(string parkingTyperesult, string carparkTyperesult)
        {

            
            model = data.SqlQuery("SELECT * From dbo.Carparks WHERE typeOfparking = '" + parkingTyperesult + "' AND carparkType = '" + carparkTyperesult + "'").ToList();
            return model;

        }
    }
}