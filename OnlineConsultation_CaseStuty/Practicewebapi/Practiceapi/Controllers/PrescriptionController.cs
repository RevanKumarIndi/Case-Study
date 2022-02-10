using Microsoft.AspNetCore.Mvc;
using Practiceapi.Models;
using Practiceapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Controllers
{
    public class PrescriptionController : Controller
    {
        private IPrescriptionServices _registration;
        //private PracticedbContext _database;
        public PrescriptionController(IPrescriptionServices registration)
        {
            _registration = registration;
            //_database = database;
        }

        [HttpPost]
        [Route("Prescription")]
        public IActionResult AddPresciption([FromBody] Prescription prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var item = _registration.AddPrescription(prescription);
            if (item != null)
            {
                return Ok(prescription);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("ListOfPrescriptionbyDoctid")]
        public IActionResult GetAllPrescriptionDetailsbyid(int Doctorid)
        {
            var doctors = _registration.GetPrescriptionByDoctorid(Doctorid);
            if (doctors.Count() != 0)
            {
                return Ok(doctors);
            }
            return NotFound();
        }
    }
}
