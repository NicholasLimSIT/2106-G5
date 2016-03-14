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
        

        public void Save()
        {
            db.SaveChanges();
        }


        
        public IEnumerable<Carpark> searchCarpark(string address)
        {
            if (address.Equals(""))
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
    }
}