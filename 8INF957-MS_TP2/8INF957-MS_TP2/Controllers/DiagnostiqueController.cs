using _8INF957_MS_TP2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi;
using RestApi.Models;

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class DiagnostiqueController : Controller
    {
        private TP2Context context;

        public DiagnostiqueController(TP2Context tp2Context)
        {
            context = tp2Context;
        }

        private List<Patient> getContextPatients()
        {
            int doctorId = int.Parse(HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
            return context.Patients.Where(p => p.DoctorId == doctorId).ToList();
        }

        public IActionResult Index()
        {
            return View(getContextPatients());
        }

        [HttpPost]
        public IActionResult ViewPatient(int id)
        {
            return RedirectToAction("View", "Patient", new { id });
        }

        [HttpPost]
        public IActionResult AjoutPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();

            return View(patient);
        }
    }
}
