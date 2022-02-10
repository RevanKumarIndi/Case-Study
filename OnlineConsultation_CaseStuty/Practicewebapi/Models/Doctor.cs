using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practicewebapi.Models
{
    public partial class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string Specilization { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
