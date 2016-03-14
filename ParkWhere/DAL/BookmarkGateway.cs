using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkWhere.Models;
using System.Data.Entity;

namespace ParkWhere.DAL
{
    public class BookmarkGateway : DataGateway<Bookmark>
    {

        public BookmarkGateway()
        {
            this.data = db.Set<Bookmark>();
        }
        public Bookmark Delete(int? id)
        {
            Bookmark obj = data.Find(id);
            data.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public void Insert(Bookmark obj)
        {
            data.Add(obj);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(Bookmark obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}