using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBackId { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
        public string Date { get; set; }
        public string FeedBack1 { get; set; }

    }
}
