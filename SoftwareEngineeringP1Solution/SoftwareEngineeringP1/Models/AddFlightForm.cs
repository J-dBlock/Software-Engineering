using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareEngineeringP1.Models
{
    public class AddFlightForm
    {
        public int startingIdNumber { get; set; }
        public int endingIdNumber { get; set; }
        public int time { get; set; }
        public int price { get; set; }

    }
}