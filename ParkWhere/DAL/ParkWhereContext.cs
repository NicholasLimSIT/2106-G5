﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ParkWhere.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ParkWhere.Models;

    public class ParkWhereDBEntities : DbContext
    {
        public ParkWhereDBEntities()
            : base("name=ParkWhereDBEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<Carpark> Carparks { get; set; }
        public virtual DbSet<ParkingHistory> ParkingHistories { get; set; }
        public virtual DbSet<PetrolStation> PetrolStations { get; set; }
    }
}
