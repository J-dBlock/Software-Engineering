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
        // Used in a unit test.
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

        public Airport GetAirportById(int id)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
           return db.Airports.SingleOrDefault(a => a.Id == id);
        }
        /// <summary>
        ///  Returns all of the flights that are located in the database. 
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetAllFlights()
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
            return db.Flights.ToList();
        }

        /// <summary>
        /// Used to add or update flights into the current database. 
        /// </summary>
        /// <param name="flight"></param>
        public void AddOrUpdateFlight(Flight flight)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
            db.Flights.AddOrUpdate(flight);
            db.SaveChanges();
        }

        public List<Flight> SearchFlights(string destination, string arrival, string country)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
                                            // Status should be true that the flight is still happening
            return db.Flights.Where(f => f.Status &&
                                            // Linq that applies the search criteria.
                                            ((destination != null && f.SourceAirport.City.Contains(destination)) ||
                                            (arrival != null  && f.DestinationAirport.City.Contains(arrival)) ||
                                            (country != null && (f.DestinationAirport.Country.Contains(country) || 
                                                                f.SourceAirport.Country.Contains(country))) )
                                                                ).ToList();
        }

        public void DeleteFlights(int id)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
            db.Flights.Remove(db.Flights.SingleOrDefault(a => a.Id == id));
            db.SaveChanges();
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
        /// Returning a signle Flight from the database by the flight idetifier.
        /// </summary>
        /// <param name="flightId">Database Id that represents the flight.</param>
        /// <returns>Flight object</returns>
        public Flight GetFlight(int flightId)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
            return db.Flights.SingleOrDefault(f => f.Id == flightId);
        }


        public void addFlight(int startingIdNumber, int endingIdNumber, int time, int price)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(startingIdNumber);
            var air2 = fda.GetAirportById(endingIdNumber);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = price,
                Status = true,
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now.AddHours(time),
                Name = startingIdNumber + "-" + endingIdNumber
            };
            db.Flights.AddOrUpdate(flight);
            db.SaveChanges();
        }

        public void DeleteFlight(int flightId)
        {
            PenguinFlightsDataContext db = new PenguinFlightsDataContext();

            var flight = GetFlight(flightId);
            if (flight != null)
            {
                flight.Status = false;
                db.Flights.AddOrUpdate(flight);
                db.SaveChanges();
            }
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