using System.Diagnostics;
using _8INF957_MS_TP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestApi;
using RestApi.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RestApi.Models.DTO;
using _8INF957_MS_TP2.Services;

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private TP2Context context;
        private ContextHelper contextHelper;

        public PatientController(TP2Context tp2Context)
        {
            context = tp2Context;
            contextHelper = new(this, tp2Context);
        }

        public IActionResult View(int id)
        {
            return View(context.Patients.Find(id));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            patient.DoctorId = contextHelper.GetDoctorId();
            context.Patients.Add(patient);
            context.SaveChanges();
            return RedirectToAction("Index", "Diagnostique");
        }
    }
}