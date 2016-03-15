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