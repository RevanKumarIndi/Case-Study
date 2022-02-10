using Newtonsoft.Json;
using OnlineConsultation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineConsultation.Controllers
{
    public class DoctorLoginController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44333/");
        HttpClient client;
        public DoctorLoginController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(DoctorLogin login)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorLogin", login).Result;
            if (response.IsSuccessStatusCode)
            {
                Session["DoctorName"] = login.DoctorName.ToString();
                FormsAuthentication.SetAuthCookie(login.DoctorName, false);
                var data = GetDoctorDetails();
                Session["Doctorid"] = data.DoctorId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Message"] = "Login Failed!!!Please Enter Correct Details";
            }
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(DoctorLogin Signup)
        {
            //HTTP POST
            var postTask = client.PostAsJsonAsync<DoctorLogin>("RegisterDoctor", Signup).Result;

            //var result = postTask.Result;
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            
            return RedirectToAction("SignIn");
        }

        public Doctor GetDoctorDetails()
        {
                Doctor AppointmentList = new Doctor();
                HttpResponseMessage response = client.GetAsync("GetDoctorByName?DoctorName=" + Session["DoctorName"]).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    AppointmentList = JsonConvert.DeserializeObject<Doctor>(data);
                    return AppointmentList;
                }
            return AppointmentList;
        }

        public ActionResult GetAllDoctors()
        {
            if (Session["Doctorid"] != null)
            {
                List<Doctor> DoctorsList = new List<Doctor>();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "ListOfDoctors").Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    DoctorsList = JsonConvert.DeserializeObject<List<Doctor>>(data);
                }
                return View(DoctorsList);
            }
            return RedirectToAction("SignIn", "DoctorLogin");
        }
    }
}