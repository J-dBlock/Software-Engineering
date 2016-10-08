using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareEngineeringP1.Models
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Altitude { get; set; }

        public double TimezoneOffset { get; set; }

        public string DST { get; set; }

        public string Timezone { get; set; }
    }
}