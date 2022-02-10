using Microsoft.Extensions.Logging;
using Practiceapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Services
{
    public class PrescriptionServices:IPrescriptionServices
    {
        private readonly ILogger _logger;
        private PracticedbContext _DbContext;
        public PrescriptionServices(PracticedbContext DbContext, ILogger<PrescriptionServices> logger)
        {
            _DbContext = DbContext;
            _logger = logger;
        }
        public Prescription AddPrescription(Prescription prescription)
        {
            try
            {
                _DbContext.Add(new Prescription()
                {
                    DoctorId = prescription.DoctorId,
                    UserId = prescription.UserId,
                    Prescription1 = prescription.Prescription1,

                });
                _DbContext.SaveChanges();
                return prescription;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return prescription;
            }
        }

        public IEnumerable<Prescription> GetPrescriptionByDoctorid(int Doctorid)
        {
            List<Prescription> result = new List<Prescription>();
            try
            {
                result = _DbContext.Prescriptions
                .Where(f => f.DoctorId == Doctorid)
                .Select(f => new Prescription
                {
                    PrescriptionId = f.PrescriptionId,
                    DoctorId = f.DoctorId,
                    UserId = f.UserId,
                    Prescription1 = f.Prescription1
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
