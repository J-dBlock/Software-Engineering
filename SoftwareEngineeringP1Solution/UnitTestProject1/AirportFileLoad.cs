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

        [TestMethod]
        public void TestingWTF()
        {
            FlightDataAccess fda = new FlightDataAccess();
            fda.WTF();
        }
    }


}
