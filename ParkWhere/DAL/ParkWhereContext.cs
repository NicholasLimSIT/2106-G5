using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ParkWhere.Models;

namespace ParkWhere.DAL
{
    public class ParkWhereContext : DbContext
    {
        public ParkWhereContext() : base("ParkWhereDB")
        {
        }
        public DbSet<Carpark> Carpark { get;set; }
    }
}