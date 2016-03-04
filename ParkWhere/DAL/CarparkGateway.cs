using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ParkWhere.Models;
using ParkWhere.DAL;

namespace ParkWhere.DAL
{
    public class CarparkGateway : ICarparkGateway
    {
        internal ParkWhereContext db = new ParkWhereContext();
        internal DbSet<Carpark> data = null;
        IEnumerable<Carpark> model;

        public CarparkGateway()
        {
            this.data = db.Set<Carpark>();
        }
        public Carpark Delete(int? id)
        {
            Carpark obj = data.Find(id);
            data.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public void Insert(Carpark obj)
        {
            data.Add(obj);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Carpark> SelectAll()
        {
            IEnumerable<Carpark> model = data.ToList();
            return model;
        }

        public Carpark SelectById(int? id)
        {
            Carpark obj = data.Find(id);
            return obj;
        }

        public void Update(Carpark obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Save();
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