using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareEngineeringP1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string Hash { get; set; }

        public int RoleId { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}