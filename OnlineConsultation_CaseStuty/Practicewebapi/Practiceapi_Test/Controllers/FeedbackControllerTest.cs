using Microsoft.AspNetCore.Mvc;
using Practiceapi.Controllers;
using Practiceapi.Services;
using Practiceapi_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Practiceapi_Test.Controllers
{
    public class FeedbackControllerTest
    {
        private readonly FeedbackController _controller;
        private readonly IFeedbackServices _services;
        public FeedbackControllerTest()
        {
            _services = new FeedbackServicesFake();
            _controller = new FeedbackController(_services);
        }
        [Fact]
        public void Get_FeedbackbyDoctorid()
        {
            //Arrange
            var DoctorId = 2;
            //Act
            var okResult = _controller.GetAllFeedbackDetailsbyid(DoctorId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
