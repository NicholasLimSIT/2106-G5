using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ParkWhere.DAL
{
    public class DataGateway<T> : IDataGateway<T> where T : class
    {
        internal ParkWhereDBEntities db = new ParkWhereDBEntities();
        internal DbSet<T> data = null;

        public DataGateway()
        {
            this.data = db.Set<T>();
        }
        public IEnumerable<T> SelectAll()
        {
            return data.ToList();
        }

        public T SelectById(int? id)
        {
            return data.Find(id);
        }
    }
}