using Practicewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Services
{
    public interface IFeedbackServices
    {
        public List<FeedBack> GetFeedbackByDoctorid(int Doctorid);
    }
}
