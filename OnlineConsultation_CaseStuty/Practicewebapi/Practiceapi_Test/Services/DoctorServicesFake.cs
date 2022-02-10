using Practiceapi.Models;
using Practiceapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceapi_Test.Services
{
    public class DoctorServicesFake : IDoctorregistrationServices
    {
        private readonly IList<Doctor> _doctor;
        public DoctorServicesFake()
        {
            _doctor = new List<Doctor>()
            {
                new Doctor(){ DoctorId = 1, DoctorName = "Raju", Gender = "Male", Email = "Raju@gmail.com", PhNo = "9685471232", Specilization = "heart", Password="12345"},
                new Doctor(){ DoctorId = 2, DoctorName = "Ramu", Gender = "Male", Email = "Ramu@gmail.com", PhNo = "9685471200", Specilization = "General", Password="12345"},
            };
        }

        public Doctor GetDoctorbyDoctorName(string DoctorName)
        {
            var data = _doctor.Where(f => f.DoctorName == DoctorName).Select(f => new Doctor()
            {
                DoctorId = f.DoctorId,
                DoctorName = f.DoctorName,
                Gender = f.Gender,
                Specilization = f.Specilization,
                PhNo = f.PhNo,
                Email = f.Email,
                Password = f.Password
            }).FirstOrDefault();
            return data;
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            _doctor.Add(doctor);
            return doctor;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctor;
        }
    }
}