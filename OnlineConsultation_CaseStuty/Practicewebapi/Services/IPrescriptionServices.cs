using Practicewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Services
{
    public interface IPrescriptionServices
    {
        public Prescription AddPrescription(Prescription prescription);
    }
}
