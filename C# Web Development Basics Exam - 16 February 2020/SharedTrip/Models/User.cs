using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            UserTrips = new HashSet<UserTrip>();
        }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
