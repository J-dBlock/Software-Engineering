using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareEngineeringP1.Models;
using System.Collections.Generic;
using SoftwareEngineeringP1.DataAccess;

namespace UnitTestProject1
{
    [TestClass]
    public class AirportFileLoad
    {
        [TestMethod]
        public void TestingDatabase()
        {
            FlightDataAccess fda = new FlightDataAccess();
            fda.GetAllAirports();
        }

        //[Ignore]
        [TestMethod]
        public void TestMethod1()
        {
            // Change this string the location of the data files for your systems.
            // There is a copy of the file in TestingAndScript -> DataFiles
            string DataFilesDirectory = @"D:\Student Data\Downloads\";

            string[] lines = System.IO.File.ReadAllLines(DataFilesDirectory + "airports.dat.txt");
            List<Airport> airports = new List<Airport>();
            List<string> errorEntries = new List<string>();
            foreach (string line in lines)
            {
                string[] airportString = line.Replace("\"", "").Split(',');

                try
                {
                    var airport = new Airport
                    {
                        Id = Int32.Parse(airportString[0]),
                        Name = airportString[1],
                        City = airportString[2],
                        Country = airportString[3],
                        Latitude = Double.Parse(airportString[6]),
                        Longitude = Double.Parse(airportString[7]),
                        Altitude = Double.Parse(airportString[8]),
                        TimezoneOffset = Double.Parse(airportString[9]),
                        DST = airportString[10],
                        Timezone = airportString[11]
                    };
                    airports.Add(airport);
                } catch (Exception e)
                {
                    errorEntries.Add(line);
                }
               
            }
            FlightDataAccess fda = new FlightDataAccess();
            fda.LoadAirports(airports);
        }

        [Ignore]
        [TestMethod]
        public void BuildTestFlights()
        {
            var fda = new FlightDataAccess();

            var air1 =  fda.GetAirportById(103);
            var air2 = fda.GetAirportById(104);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 250,
                Status = true,
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(3),
                Name = "Random Flight"
            };
            fda.AddOrUpdateFlight(flight);
        }

       // [Ignore]
        [TestMethod]
        public void LoadAllNewFlights()
        {
            BuildTestFlights1();
            BuildTestFlights2();
            BuildTestFlights3();
            BuildTestFlights4();
            BuildTestFlights5();
            BuildTestFlights6();
            BuildTestFlights7();
            BuildTestFlights8();
            BuildTestFlights9();
            BuildTestFlights10();
            BuildTestFlights11();
            BuildTestFlights12();
            BuildTestFlights13();
            BuildTestFlights14();
            BuildTestFlights15();
            BuildTestFlights16();
            BuildTestFlights17();
            BuildTestFlights18();
        }
        public void BuildTestFlights1()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(1189);
            var air2 = fda.GetAirportById(3674);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 956,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(13),
                Name = "1189-3674"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights2()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3503);
            var air2 = fda.GetAirportById(2856);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 1954,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(30),
                Name = "3503-2856"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights3()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3392);
            var air2 = fda.GetAirportById(3563);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 102,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(3),
                Name = "3392-3563"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights4()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(6751);
            var air2 = fda.GetAirportById(3530);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 224,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(5),
                Name = "6751-2530"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights5()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(4136);
            var air2 = fda.GetAirportById(3461);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 480,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(6),
                Name = "4136-3461"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights6()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3563);
            var air2 = fda.GetAirportById(2739);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 704,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(14),
                Name = "3563-2739"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights7()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3674);
            var air2 = fda.GetAirportById(6906);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 1028,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(17),
                Name = "3674-6906"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights8()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(5106);
            var air2 = fda.GetAirportById(6575);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 517,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(3),
                Name = "3674-6906"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights9()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(7472);
            var air2 = fda.GetAirportById(1103);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 306,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(3),
                Name = "7472-1103"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights10()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(4630);
            var air2 = fda.GetAirportById(3392);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 200,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(1),
                Name = "4630-3392"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights11()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(1716);
            var air2 = fda.GetAirportById(5534);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 527,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(4),
                Name = "1716-5534"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights12()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3694);
            var air2 = fda.GetAirportById(7540);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 1035,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(8),
                Name = "3694-7540"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights13()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3544);
            var air2 = fda.GetAirportById(6575);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 944,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(7),
                Name = "3544-6575"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights14()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(4026);
            var air2 = fda.GetAirportById(6869);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 270,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(4),
                Name = "4026-6869"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights15()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(6981);
            var air2 = fda.GetAirportById(7592);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 263,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(4),
                Name = "6981-7592"
            };
            fda.AddOrUpdateFlight(flight);
        }
        
        public void BuildTestFlights16()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(7458);
            var air2 = fda.GetAirportById(3563);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 1346,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(8),
                Name = "7458-3563"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights17()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3182);
            var air2 = fda.GetAirportById(3674);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 1958,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(23),
                Name = "3182-3674"
            };
            fda.AddOrUpdateFlight(flight);
        }

        public void BuildTestFlights18()
        {
            var fda = new FlightDataAccess();

            var air1 = fda.GetAirportById(3566);
            var air2 = fda.GetAirportById(7436);
            var flight = new Flight()
            {
                SourceAirport = air1,
                DestinationAirport = air2,
                SourceAirportId = air1.Id,
                DestinationAirportId = air2.Id,
                Price = 387,
                Status = true,
                DepartureTime = DateTime.Now.AddDays(3),
                ArrivalTime = DateTime.Now.AddDays(3).AddHours(5),
                Name = "3566-7436"
            };
            fda.AddOrUpdateFlight(flight);
        }

    }
}
