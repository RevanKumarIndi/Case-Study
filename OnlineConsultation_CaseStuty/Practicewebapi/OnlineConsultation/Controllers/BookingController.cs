using Newtonsoft.Json;
using OnlineConsultation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using CasestudyKendoUI.Models;
using System.Web;
using System.Web.Mvc;

namespace OnlineConsultation.Controllers
{
    public class BookingController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44333/");
        HttpClient client;

        public BookingController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: Appointments
        public ActionResult Get_Bookings()
        {
            if (Session["DoctorName"] != null)
            {
                List<Booking> AppointmentList = new List<Booking>();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress+ "ListOfDoctors").Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    AppointmentList = JsonConvert.DeserializeObject<List<Booking>>(data);
                    
                }
            return View(AppointmentList);
            }
            return RedirectToAction("SignIn", "DoctorLogin");
        }

        public ActionResult GetBookingsbyDoctorId()
        {
            if (Session["Doctorid"] != null)
            {
                List<Booking> AppointmentList = new List<Booking>();
                HttpResponseMessage response = client.GetAsync("ListOfBookingsbyDoctid?Doctorid=" + Session["Doctorid"]).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    AppointmentList = JsonConvert.DeserializeObject<List<Booking>>(data);

                }
                return View(AppointmentList);
            }
            return RedirectToAction("SignIn", "DoctorLogin");
        }
    }
}