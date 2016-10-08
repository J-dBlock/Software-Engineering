using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareEngineeringP1.Models;


namespace UnitTestProject1
{
    [TestClass]
    public class AirportFileLoad
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mitch\Documents\Fall 2016\airports.dat.txt");

            foreach (string line in lines)
            {
                string[] airportString = line.Split(',');

                var airport = new Airport
                {
                    Id = Int32.Parse(airportString[0])
                };
            }
        }
    }
}
