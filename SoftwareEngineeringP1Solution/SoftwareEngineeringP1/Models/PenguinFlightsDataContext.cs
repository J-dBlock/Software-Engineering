using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SoftwareEngineeringP1.Models
{
    public class PenguinFlightsDataContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<Passenger> Passengers { get; set; }


        public PenguinFlightsDataContext() : base ("PenguinFlightsData")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}