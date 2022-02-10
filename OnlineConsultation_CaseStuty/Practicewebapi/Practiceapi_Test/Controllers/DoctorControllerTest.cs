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
    public class DoctorControllerTest
    {
        private readonly DoctorController _controller;
        private readonly IDoctorregistrationServices _service;
        private PracticedbContext _database;

        public DoctorControllerTest()
        {
            _service = new DoctorServicesFake();
            _controller = new DoctorController(_service,_database);
        }

        [Fact]
        public void AddNewDoctors_ShouldReturnSuccess()
        {
            //Arrange
            Doctor testItem = new Doctor()
            {
                DoctorId = 3,
                DoctorName = "ravi",
                Gender = "male",
                Specilization = "heart",
                PhNo = "8547961235",
                Email = "ravi@gmail.com",
                Password = "12345"
            };
            // Act
            IActionResult createdResponse = _controller.AddDoctor(testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse as OkObjectResult);
        }

        [Fact]
        public void GetallDoctors_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllDoctorDetails();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetDoctorsbyDoctorName_ReturnsOkResult()
        {
            //Arrange
            var DoctorName = "Raju";
            //Act
            var okResult = _controller.GetDoctorbyDoctorName(DoctorName);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
