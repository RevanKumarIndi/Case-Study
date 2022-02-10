using Microsoft.AspNetCore.Mvc;
using Practiceapi.Controllers;
using Practiceapi.Models;
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
    public class PrescriptionControllerTest
    {
        private readonly PrescriptionController _controller;
        private readonly IPrescriptionServices _service;

        public PrescriptionControllerTest()
        {
            _service = new PrescriptionServicesFake();
            _controller = new PrescriptionController(_service);
        }

        [Fact]
        public void Get_PrescriptionbyDoctorid()
        {
            //Arrange
            var DoctorId = 2;
            //Act
            var okResult = _controller.GetAllPrescriptionDetailsbyid(DoctorId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void AddNewPrescription_ShouldReturnSuccess()
        {
            // Arrange
            var testItem = new Prescription()
            {
                PrescriptionId = 5,
                DoctorId = 6,
                UserId = 4,
                Prescription1 = "Dolo1"
            };
            // Act
            IActionResult createdResponse = _controller.AddPresciption(testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse as OkObjectResult);
        }
    }
}
