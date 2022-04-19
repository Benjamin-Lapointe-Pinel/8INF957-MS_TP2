using System.Diagnostics;
using _8INF957_MS_TP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestApi;
using RestApi.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Connexion()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Informations()
        {
            return View();
        }
        // gerer et mettre a jour les informations du medecin
        [HttpPost]
        public IActionResult Informations(int Id,string firstname)
        {
            if (ModelState.IsValid) {
                TP2Context db = new TP2Context();
                Doctor doctor = db.Doctors.Find(Id);
                doctor.FirstName = firstname;
                db.SaveChanges();
            }
            
            return View();
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

        //public IActionResult CreerCompte(Models.Doctor doctor)
        //{
        //    Models.TP2Context db = new Models.TP2Context();
        //    db.Doctors.Add(doctor);
        //    db.SaveChanges();
        //    return View(doctor);
        //}
        
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
       // [Authorize(Roles = "Admin, User")]
        public IActionResult login()
        {
            return View();
        }
        
      
       
    }
}