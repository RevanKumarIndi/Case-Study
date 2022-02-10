using Microsoft.Extensions.Logging;
using Practiceapi.Models;
using Practiceapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Services
{
    public class DoctorregistrationServices : IDoctorregistrationServices
    {
        private readonly ILogger _logger;
        private PracticedbContext _DbContext;
        public DoctorregistrationServices(PracticedbContext DbContext , ILogger<DoctorregistrationServices> logger)
        {
            _DbContext = DbContext;
            _logger = logger;
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            try
            {
                _DbContext.Add(new Doctor()
                {
                    DoctorName = doctor.DoctorName,
                    Gender = doctor.Gender,
                    Specilization = doctor.Specilization,
                    PhNo = doctor.PhNo,
                    Email = doctor.Email,
                    Password = doctor.Password
                });
                _DbContext.SaveChanges();
                return doctor;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return doctor;
            }
        }
        public Doctor GetDoctorbyDoctorName(string DoctorName)
        {
            Doctor doctor = new Doctor();
            try
            {
                doctor = _DbContext.Doctors.Where(f => f.DoctorName == DoctorName).Select(f => new Doctor()
                {
                    DoctorId=f.DoctorId,
                    DoctorName = f.DoctorName,
                    Gender = f.Gender,
                    Specilization = f.Specilization,
                    PhNo = f.PhNo,
                    Email = f.Email,
                    Password = f.Password
                }).FirstOrDefault();
                return doctor;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return doctor;
            }
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            List<Doctor> result = new List<Doctor>();
            try
            {
                result = _DbContext.Doctors
                .Select(f => new Doctor
                {
                    DoctorId = f.DoctorId,
                    DoctorName = f.DoctorName,
                    Gender = f.Gender,
                    Specilization = f.Specilization,
                    PhNo = f.PhNo,
                    Email = f.Email,
                    Password = f.Password
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
