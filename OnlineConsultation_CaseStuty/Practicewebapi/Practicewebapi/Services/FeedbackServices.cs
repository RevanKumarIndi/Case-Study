using Microsoft.Extensions.Logging;
using Practicewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicewebapi.Services
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly ILogger _logger;
        private PracticedbContext _DbContext;
        public FeedbackServices(PracticedbContext DbContext, ILogger<FeedbackServices> logger)
        {
            _DbContext = DbContext;
            _logger = logger;
        }
        public List<FeedBack> GetFeedbackByDoctorid(int Doctorid)
        {
            List<FeedBack> result = new List<FeedBack>();
            try
            {
                result = _DbContext.FeedBacks
                .Where(f => f.DoctorId == Doctorid)
                .Select(f => new FeedBack
                {
                    FeedBackId = f.FeedBackId,
                    UserId = f.UserId,
                    DoctorId = f.DoctorId,
                    Date = f.Date
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
