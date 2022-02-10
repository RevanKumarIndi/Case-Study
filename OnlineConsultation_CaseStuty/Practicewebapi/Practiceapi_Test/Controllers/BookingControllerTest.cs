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
    public class BookingControllerTest
    {
        private readonly BookingController _controller;
        private readonly IBookingServices _services;
        public BookingControllerTest()
        {
            _services = new BookingServicesFake();
            _controller = new BookingController(_services);
        }
        [Fact]
        public void Get_BookingsbyDoctorid()
        {
            //Arrange
            var DoctorId = 2;
            //Act
            var okResult = _controller.GetAllBookingDetailsbyid(DoctorId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
