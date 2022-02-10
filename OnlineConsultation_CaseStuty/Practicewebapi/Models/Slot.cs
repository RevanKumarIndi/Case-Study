using System;
using System.Collections.Generic;

#nullable disable

namespace Practicewebapi.Models
{
    public partial class Slot
    {
        public int SlotId { get; set; }
        public int? DoctorId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Availability { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
