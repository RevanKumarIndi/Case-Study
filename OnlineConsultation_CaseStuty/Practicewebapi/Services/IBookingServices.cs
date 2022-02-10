using Practicewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Services
{
    public interface IBookingServices
    {
        public List<Booking> GetBookedPatientDetails();
        public List<Booking> GetBookedPatientDetailsbyid(int Doctorid);
        
    }
}
