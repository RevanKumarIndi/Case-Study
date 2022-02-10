using Practiceapi.Models;
using Practiceapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceapi_Test.Services
{
    public class PrescriptionServicesFake: IPrescriptionServices
    {
        private readonly IList<Prescription> _prescription;

        public PrescriptionServicesFake()
        {
            _prescription = new List<Prescription>()
            {
                new Prescription(){ PrescriptionId = 1,DoctorId = 2,UserId = 3,Prescription1 ="Dolo"},
                new Prescription(){ PrescriptionId = 2,DoctorId = 3,UserId = 4,Prescription1 ="Dolo"},
            };
        }
        public IEnumerable<Prescription> GetPrescriptionByDoctorid(int Doctorid)
        {
            var data = _prescription.Where(a => a.DoctorId == Doctorid).FirstOrDefault();
            yield return data;
        }

        public Prescription AddPrescription(Prescription prescription)
        {
            _prescription.Add(prescription);
            return prescription;
        }

    }
}
