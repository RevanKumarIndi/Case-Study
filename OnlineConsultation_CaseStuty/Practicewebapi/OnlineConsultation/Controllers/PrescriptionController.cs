using Newtonsoft.Json;
using OnlineConsultation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OnlineConsultation.Controllers
{
    public class PrescriptionController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44333/");
        HttpClient client;

        public PrescriptionController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult GetPrescriptionbyDoctorId()
        {
            if (Session["Doctorid"] != null)
            {
                List<Prescription> PrescriptionList = new List<Prescription>();
                HttpResponseMessage response = client.GetAsync("ListOfPrescriptionbyDoctid?Doctorid=" + Session["Doctorid"]).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    PrescriptionList = JsonConvert.DeserializeObject<List<Prescription>>(data);

                }
                return View(PrescriptionList);
            }
            return RedirectToAction("SignIn", "DoctorLogin");
        }

        public ActionResult AddPrescription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPrescription(Prescription prescription)
        {
            //HTTP POST
            var postTask = client.PostAsJsonAsync<Prescription>("Prescription",prescription).Result;

            //var result = postTask.Result;
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("GetPrescriptionbyDoctorId");
            }
            return View();
        }
    }
}