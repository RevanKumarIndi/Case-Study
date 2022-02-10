using Practiceapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Services
{
    public interface IDoctorregistrationServices
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor GetDoctorbyDoctorName(string DoctorName);
        public IEnumerable<Doctor> GetAllDoctors();
    }
}
