using Practiceapi.Models;
using Practiceapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceapi_Test.Services
{
    public class FeedbackServicesFake:IFeedbackServices
    {
        private readonly IList<FeedBack> feedBacks;
        public FeedbackServicesFake()
        {
            feedBacks = new List<FeedBack>()
            {
                new FeedBack(){ FeedBackId=1, DoctorId=2, UserId=2, FeedBack1="Good", Date="01/01/1999"},
                new FeedBack(){ FeedBackId=2, DoctorId=3, UserId=5, FeedBack1="Bad", Date="02/02/1999"},
            };
        }

        public IEnumerable<FeedBack> GetFeedbackByDoctorid(int Doctorid)
        {
            var data = feedBacks.Where(a => a.DoctorId == Doctorid).FirstOrDefault();
            yield return data;
        }
    }
}
