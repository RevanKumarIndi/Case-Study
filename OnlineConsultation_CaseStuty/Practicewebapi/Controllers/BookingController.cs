using Microsoft.AspNetCore.Mvc;
using Practicewebapi.Models;
using Practicewebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Controllers
{
    public class BookingController : Controller
    {
        private IBookingServices _registration;
        private PracticedbContext _database;
        public BookingController(IBookingServices registration, PracticedbContext database)
        {
            _registration = registration;
            _database = database;
        }

        [HttpGet]
        [Route("ListOfBookings")]
        public IActionResult GetAllBookingDetails()
        {
            var doctors = _registration.GetBookedPatientDetails();
            if (doctors.Count != 0)
            {
                return Ok(doctors);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("ListOfBookingsbyDoctid")]
        public IActionResult GetAllBookingDetailsbyid(int Doctorid)
        {
            var doctors = _registration.GetBookedPatientDetailsbyid(Doctorid);
            if (doctors.Count != 0)
            {
                return Ok(doctors);
            }
            return NotFound();
        }
    }
}
