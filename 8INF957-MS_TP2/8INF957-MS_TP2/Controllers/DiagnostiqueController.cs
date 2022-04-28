using _8INF957_MS_TP2.Models;
using _8INF957_MS_TP2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi;
using RestApi.Models;

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class DiagnostiqueController : Controller
    {
        private ContextHelper contextHelper;

        public DiagnostiqueController(TP2Context tp2Context)
        {
            contextHelper = new(this, tp2Context);
        }

        public IActionResult Index()
        {
            return View(contextHelper.getContextPatients());
        }

        [HttpPost]
        public IActionResult ViewPatient(int id)
        {
            return RedirectToAction("View", "Patient", new { id });
        }

        [HttpPost]
        public IActionResult AddPatient()
        {
            return RedirectToAction("Add", "Patient");
        }
    }
}
