using Practiceapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Services
{
    public interface IBookingServices
    {
        //public List<Booking> GetBookedPatientDetails();
        public IEnumerable<Booking> GetBookedPatientDetailsbyid(int Doctorid);
        
    }
}
