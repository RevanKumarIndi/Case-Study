using Microsoft.AspNetCore.Mvc;
using Practiceapi.Models;
using Practiceapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackServices _registration;
        //private PracticedbContext _database;
        public FeedbackController(IFeedbackServices registration)
        {
            _registration = registration;
            //_database = database;
        }
        [HttpGet]
        [Route("ListOfFeedbacksbyDoctid")]
        public IActionResult GetAllFeedbackDetailsbyid(int Doctorid)
        {
            var doctors = _registration.GetFeedbackByDoctorid(Doctorid);
            if (doctors.Count() != 0)
            {
                return Ok(doctors);
            }
            return NotFound();
        }
    }
}
