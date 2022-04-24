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

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class InformationsController : Controller
    {
        private TP2Context context;

        public InformationsController(TP2Context tp2Context)
        {
            context = tp2Context;
        }
        
        [HttpPost]
        public IActionResult ViewPatient(PatientsList patientsList)
        {
            return View("Patients", patientsList.SelectedPatientId);
        }
        [HttpGet]
        public IActionResult AjoutPatient()
        {
            return View();
        }
        //ajouter un patient
        [HttpPost]
        public IActionResult AjoutPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();

            return View(patient);
        }
        //suprimer un patient
        [HttpDelete]
        public  IActionResult AjoutPatient(int Id)
        {
            Patient patient = context.Patients.Find(Id);
            context.Patients.Remove(patient);
            context.SaveChanges();
            return View(patient);

        }
        // supprimer un diagnostique  d'un patient
        public IActionResult AjoutPatient(string Firstname)
        {
            Patient patient = context.Patients.Find(Firstname);
            context.Patients.Remove(patient);
            context.SaveChanges();
            return View(patient);

        }
    }
}