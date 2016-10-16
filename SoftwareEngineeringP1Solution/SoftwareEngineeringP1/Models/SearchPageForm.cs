using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareEngineeringP1.Models
{
    public class SearchPageForm
    {
        public string Search { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
        public List<Flight> flightResults { get; set; }
    }
}