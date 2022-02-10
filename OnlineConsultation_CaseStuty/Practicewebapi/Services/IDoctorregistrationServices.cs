using Practicewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Services
{
    public interface IDoctorregistrationServices
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor GetDoctorbyDoctorName(string DoctorName);
    }
}
