using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareEngineeringP1.Models
{
    public class FlightUserPageForm
    {
        public Flight Flight { get; set; }

        public bool IsAdmin { get; set; }
    }
}