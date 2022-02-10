using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OnlineConsultation.Models
{
    public partial class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
        public string Prescription1 { get; set; }

        //public virtual Doctor Doctor { get; set; }
        //public virtual User User { get; set; }
    }
}
