using Practiceapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Services
{
    public interface IPrescriptionServices
    {
        public Prescription AddPrescription(Prescription prescription);
        public IEnumerable<Prescription> GetPrescriptionByDoctorid(int Doctorid);
    }
}
