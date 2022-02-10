using Microsoft.AspNetCore.Mvc;
using Practicewebapi.Models;
using Practicewebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Controllers
{
    public class PrescriptionController : Controller
    {
        private IPrescriptionServices _registration;
        private PracticedbContext _database;
        public PrescriptionController(IPrescriptionServices registration, PracticedbContext database)
        {
            _registration = registration;
            _database = database;
        }

        [HttpPost]
        [Route("Prescription")]
        public IActionResult AddPresciption(Prescription prescription)
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
    }
}
