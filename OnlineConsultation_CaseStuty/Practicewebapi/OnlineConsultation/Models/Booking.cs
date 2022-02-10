using System;
using System.Collections.Generic;

namespace OnlineConsultation.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? UserId { get; set; }
        public int? DoctorId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Problem { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DoctorReview { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }
    }
}
