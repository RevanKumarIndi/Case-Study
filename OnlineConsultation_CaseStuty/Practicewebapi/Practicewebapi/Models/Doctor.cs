using System;
using System.Collections.Generic;

#nullable disable

namespace Practicewebapi.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Bookings = new HashSet<Booking>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string Specilization { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
