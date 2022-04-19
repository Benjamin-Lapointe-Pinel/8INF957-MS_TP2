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

        private Doctor getContextDoctor()
        {
            int doctorId = int.Parse(HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
            return context.Doctors.Find(doctorId);
        }

        [HttpGet]
        public IActionResult Index()
        {
            Doctor? doctor = getContextDoctor();
            if (doctor == null)
            {
                return RedirectToAction("Login");
            }
            return View(doctor);
        }

        [HttpPost]
        public IActionResult UpdateInformations(Doctor formDoctor)
        {
            try
            {
                Doctor? doctor = getContextDoctor();
                if (doctor == null)
                {
                    return RedirectToAction("Login");
                }

                doctor.FirstName = formDoctor.FirstName;
                doctor.LastName = formDoctor.LastName;
                doctor.Birthdate = formDoctor.Birthdate;
                doctor.Gender = formDoctor.Gender;
                doctor.City = formDoctor.City;
                doctor.DateEntryOffice = formDoctor.DateEntryOffice;
                doctor.Email = formDoctor.Email;
                context.SaveChanges();
                return View("Index");
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        public IActionResult Diagnostique()
        {
            return View(new PatientsList(new List<Patient>()));
        }

        public IActionResult ConfigurationIA()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreerCompte()
        {
            return View();
        }
        //Ajouter une liste de Doctors
        [HttpPost]
        public IActionResult CreerCompte(List<Doctor>doctors)
        {
            if (ModelState.IsValid)
            {
                TP2Context db = new TP2Context();
                db.Doctors.AddRange(doctors);
                db.SaveChanges();
                return RedirectToAction("Résultat", doctors);
            }else
            return View(doctors);
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
            TP2Context db = new TP2Context();
            db.Patients.Add(patient);
            db.SaveChanges();

            return View(patient);
        }
        //suprimer un patient
        [HttpDelete]
        public  IActionResult AjoutPatient(int Id)
        {
            TP2Context db = new TP2Context();
            Patient patient = db.Patients.Find(Id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return View(patient);

        }
        // supprimer un diagnostique  d'un patient
        public IActionResult AjoutPatient(string Firstname)
        {
            TP2Context db = new TP2Context();
            Patient patient = db.Patients.Find(Firstname);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return View(patient);

        }
    }
}