using System;
using System.Collections.Generic;

#nullable disable

namespace Practiceapi.Models
{
    public partial class Prescription
    {
        public int PrescriptionId { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
        public string Prescription1 { get; set; }

        //public virtual Doctor Doctor { get; set; }
        //public virtual User User { get; set; }
    }
}
