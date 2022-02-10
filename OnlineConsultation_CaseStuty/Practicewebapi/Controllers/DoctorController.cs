using Microsoft.AspNetCore.Mvc;
using Practicewebapi.Models;
using Practicewebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorregistrationServices _registration;
        private PracticedbContext _database;
        public DoctorController(IDoctorregistrationServices registration, PracticedbContext database) 
        {
            _registration = registration;
            _database= database;
        }

        [HttpPost]
        [Route("RegisterDoctor")]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var item = _registration.AddDoctor(doctor);
            if (item != null)
            {
                return Ok(doctor);
            }
            return NoContent();
        }

        [HttpPost("DoctorLogin")]
        public IActionResult DoctorLogin([FromBody] DoctorLogin login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            else
            {
                var log = _database.Doctors.Where(x => x.DoctorName == login.DoctorName && x.Password == login.Password).FirstOrDefault();
                if (log != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In Successfully"
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = "404",
                        message = "Login Failed"
                    });
                }
            }
        }
        [HttpGet]
        [Route("GetDoctorByName")]
        public IActionResult GetDoctorbyDoctorName(string DoctorName)
        {
            var doctors = _registration.GetDoctorbyDoctorName(DoctorName);
            if (doctors != null)
            {
                return Ok(doctors);
            }
            return NotFound();
        }
    }
}
