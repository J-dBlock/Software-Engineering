using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SoftwareEngineeringP1.Models
{
    public class AddFlightForm
    {
        [Key]
        public int startingIdNumber { get; set; }

        public int endingIdNumber { get; set; }

        public int time { get; set; }

        public int price { get; set; }
    }
}