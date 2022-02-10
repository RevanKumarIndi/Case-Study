using Practiceapi.Models;
using Practiceapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceapi_Test.Services
{
    public class BookingServicesFake:IBookingServices
    {
        private readonly IList<Booking> bookings;
        public BookingServicesFake()
        {
            bookings = new List<Booking>()
            {
                new Booking(){ BookingId=1, UserId=1, DoctorId=2, Gender="male", StartTime="10:00Am", Weight="90", Date="02/10/1999", EndTime="12:00Am", Height="5.5", PatientName="Raja", DoctorReview="good", Problem="zxc"},
                new Booking(){ BookingId=2, UserId=3, DoctorId=5, Gender="male", StartTime="9:00Am", Weight="50", Date="03/09/1999", EndTime="01:00pm", Height="5.6", PatientName="Rajesh", DoctorReview="Bad", Problem="pkaj"},
            };
        }

        public IEnumerable<Booking> GetBookedPatientDetailsbyid(int Doctorid)
        {
            var data= bookings.Where(a => a.DoctorId ==Doctorid).FirstOrDefault();
            yield return data;
        }
    }

}
