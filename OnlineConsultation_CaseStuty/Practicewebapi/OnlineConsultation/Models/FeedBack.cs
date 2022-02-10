using System;
using System.Collections.Generic;

//#nullable disable

namespace OnlineConsultation.Models
{
    public partial class FeedBack
    {
        public int FeedBackId { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
        public string FeedBack1 { get; set; }
        public string Date { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }
    }
}
