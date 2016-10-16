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

        /// <summary>
        /// based on the user that is logged in, get the flights where that user is a passanger of. 
        /// </summary>
        /// <param name="UserId">The AspNetUser Id.</param>
        /// <returns>List of Flights user is tied to</returns>
        public List<Flight> GetUsersFlights(string UserId)
        {
            List<Flight> flights = new List<Flight>();
            try
            {
                PenguinFlightsDataContext db = new PenguinFlightsDataContext();
                var passangerUser = db.Passengers.Where(p => p.UserId.Equals(UserId));
                flights = passangerUser.Select(pu => pu.Flight).ToList();
            }
            catch (Exception ex)
            {
                // todo: Logging... lol
            }
            return flights;
        }

        /// <summary>
        /// Calling this will make the user a passenger of a flight. 
        /// </summary>
        /// <param name="UserId">Id of the User.</param>
        /// <param name="flight"></param>
        /// <returns>If it was successful in adding the user to the flight.</returns>
        public bool AddPassenger(string userId, Flight flight)
        {
            try
            {
                PenguinFlightsDataContext db = new PenguinFlightsDataContext();
                var dbFlight = db.Flights.SingleOrDefault(f => f.Id == flight.Id);    // basically checks the flight is in the database. 
                //todo: Should validate user exists?
                var passenger = new Passenger()
                {
                    UserId = userId,
                    Flight = dbFlight,

                };
                db.Passengers.Add(passenger);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // todo : logging... lol
                return false;
            }
        }
    }
}