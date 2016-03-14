using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkWhere.Models;
using System.Data.Entity;

namespace ParkWhere.DAL
{
    public class ParkingHistoryGateway : DataGateway<ParkingHistory>
    {
        public ParkingHistoryGateway()
        {
            this.data = db.Set<ParkingHistory>();
        }
        public ParkingHistory Delete(int? id)
        {
            ParkingHistory obj = data.Find(id);
            data.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public void Insert(ParkingHistory obj)
        {
            data.Add(obj);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(ParkingHistory obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}