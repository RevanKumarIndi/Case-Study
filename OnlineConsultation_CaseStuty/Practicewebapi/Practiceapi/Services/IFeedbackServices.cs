using Practiceapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practiceapi.Services
{
    public interface IFeedbackServices
    {
        public IEnumerable<FeedBack> GetFeedbackByDoctorid(int Doctorid);
    }
}
