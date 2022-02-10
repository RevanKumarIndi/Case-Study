using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineConsultation.Data
{
    public class OnlineConsultationContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public OnlineConsultationContext() : base("name=OnlineConsultationContext")
        {
        }

        public System.Data.Entity.DbSet<OnlineConsultation.Models.Booking> Bookings { get; set; }
        public System.Data.Entity.DbSet<OnlineConsultation.Models.Doctor> Doctors { get; set; }
        public System.Data.Entity.DbSet<OnlineConsultation.Models.DoctorLogin> DoctorLogins { get; set; }
        public System.Data.Entity.DbSet<OnlineConsultation.Models.Prescription> Prescriptions { get; set; }
        public System.Data.Entity.DbSet<OnlineConsultation.Models.User> Users { get; set; }

    }
}
