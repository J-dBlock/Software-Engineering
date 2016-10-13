using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using SoftwareEngineeringP1.Models;

namespace SoftwareEngineeringP1.DataAccess
{

    /// <summary>
    /// This is the class for interfacing with the database. All calls get and update objects should be handled through
    /// </summary>
    public class FlightDataAccess
    {

        public void LoadAirports(List<Airport> airports)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
            db.Airports.AddRange(airports);
            db.SaveChanges();
        }

        public List<Airport> GetAllAirports()
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
            return db.Airports.ToList();
        }
    }
}