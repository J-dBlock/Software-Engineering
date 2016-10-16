using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SoftwareEngineeringP1.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        // This should be a getter only be a generation of the source and sestination/ and Identifier
        public string Name { get; set; }

        // All datetime should be in UTC
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public bool Status { get; set; }

        public double Price { get; set; }

        public int SourceAirportId { get; set; }
        
        public virtual Airport SourceAirport { get; set; }

        public int DestinationAirportId { get; set; }

        public virtual Airport DestinationAirport { get; set;  }
    }
}