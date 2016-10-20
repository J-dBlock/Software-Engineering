using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareEngineeringP1.Models
{
    public class SearchPageForm
    {
        public string Search { get; set; }
        public string Country { get; set; }
        public string StartCity { get; set; }
        public string DestinationCity { get; set; }
        public List<Flight> flightResults { get; set; }
    }
}