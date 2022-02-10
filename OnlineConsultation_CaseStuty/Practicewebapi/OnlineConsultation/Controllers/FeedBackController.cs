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
    public class FeedBackController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44333/");
        HttpClient client;

        public FeedBackController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: Doctors
        public ActionResult GetFeedBackbyDoctorId()
        {
            if (Session["Doctorid"] != null)
            {
                List<FeedBack> FeedbackList = new List<FeedBack>();
                HttpResponseMessage response = client.GetAsync("ListOfFeedbacksbyDoctid?Doctorid=" + Session["Doctorid"]).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    FeedbackList = JsonConvert.DeserializeObject<List<FeedBack>>(data);

                }
                return View(FeedbackList);
            }
            return RedirectToAction("SignIn", "DoctorLogin");
        }
    }
}