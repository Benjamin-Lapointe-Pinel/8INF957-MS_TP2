using System.Diagnostics;
using _8INF957_MS_TP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static _8INF957_MS_TP2.Person;

namespace _8INF957_MS_TP2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Informations()
        {
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

        [HttpPost]
        public IActionResult ViewPatient(PatientsList patientsList)
        {
            return View("Patients", patientsList.SelectedPatientId);
        }

        public IActionResult ConfigurationIA()
        {
            return View();
        }
    }
}