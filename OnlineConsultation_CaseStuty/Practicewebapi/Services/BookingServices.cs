using Microsoft.Extensions.Logging;
using Practicewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Services
{
    public class BookingServices:IBookingServices
    {
        private readonly ILogger _logger;
        private PracticedbContext _DbContext;
        public BookingServices(PracticedbContext DbContext, ILogger<BookingServices> logger)
        {
            _DbContext = DbContext;
            _logger = logger;
        }
        public List<Booking> GetBookedPatientDetails()
        {
            List<Booking> result = new List<Booking>();
            try
            {
                result = _DbContext.Bookings
                .Select(f => new Booking
                {
                    BookingId = f.BookingId,
                    UserId = f.UserId,
                    DoctorId = f.DoctorId,
                    PatientName=f.PatientName,
                    Gender = f.Gender,
                    Height=f.Height,
                    Weight=f.Weight,
                    Problem = f.Problem,
                    Date=f.Date,
                    StartTime = f.StartTime,
                    EndTime = f.EndTime
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }
        }

        public List<Booking> GetBookedPatientDetailsbyid(int Doctorid)
        {
            List<Booking> result = new List<Booking>();
            try
            {
                result = _DbContext.Bookings
                .Where(f=>f.DoctorId == Doctorid)
                .Select(f => new Booking
                {
                    BookingId = f.BookingId,
                    UserId = f.UserId,
                    DoctorId = f.DoctorId,
                    PatientName = f.PatientName,
                    Gender = f.Gender,
                    Height = f.Height,
                    Weight = f.Weight,
                    Problem = f.Problem,
                    Date = f.Date,
                    StartTime = f.StartTime,
                    EndTime = f.EndTime
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }
        }
    }
}
