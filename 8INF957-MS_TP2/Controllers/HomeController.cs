using System.Diagnostics;
using _8INF957_MS_TP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static _8INF957_MS_TP2.Person;
using static _8INF957_MS_TP2.Patient;
using _8INF957_MS_TP2.Models.Patient;


namespace _8INF957_MS_TP2.Controllers
{
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
                TP2Context db = new Models.TP2Context();
                Models.Doctor doctor = db.Doctors.Find(Id);
                doctor.FirstName = firstname;
                db.SaveChanges();
            }
            
            return View();
        }

        public IActionResult Diagnostique()
        {
            return View(new PatientsList(new List<Patient>()
            {
                new Patient("Benjamin", "Lapointe-Pinel", new(1995, 11, 13), GenderEnum.Man, "Rimouski"),
                new Patient("Zaid", "Tidjet", new(1995, 7, 5), GenderEnum.Man, "Rimouski")
            }));
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
        public IActionResult CreerCompte(List<Models.Doctor>doctors)

        {
            if (ModelState.IsValid)
            {

                Models.TP2Context db = new Models.TP2Context();
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
        public IActionResult AjoutPatient(Models.Patient patient)
        {
            Models.TP2Context db = new Models.TP2Context();
            db.Patients.Add(patient);
            db.SaveChanges();

            return View(patient);
        }
        [HttpDelete]
        public  IActionResult AjoutPatient(int Id)
        {
            TP2Context db = new TP2Context();
            Models.PatientsList.patient = db.Patients.Find(Id);
            db.Patients.Remove(PatientList);
            db.SaveChanges();
            return View(patientList);

        }
        public IActionResult Résult(Models.Doctor doctor)
        {
            return View(doctor);
        }
       
    }
}