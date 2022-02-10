using System;
using System.Collections.Generic;

#nullable disable

namespace Practicewebapi.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
