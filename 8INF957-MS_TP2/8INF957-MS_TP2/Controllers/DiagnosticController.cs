using _8INF957_MS_TP2.Services;
using _8INF957_MS_TP2.ViewModels;
using KnnLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi;
using RestApi.Models;

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class DiagnosticController : Controller
    {
        private TP2Context context;
        private ContextHelper contextHelper;

        public DiagnosticController(TP2Context tp2Context)
        {
            this.context = tp2Context;
            contextHelper = new(this, tp2Context);
        }

        public IActionResult Index()
        {
            ViewBag.Result = TempData["Result"];
            return View(new DiagnosticViewModel(contextHelper.getContextPatients()));
        }

        [HttpPost]
        public IActionResult ViewPatient(DiagnosticViewModel diagnosticViewModel)
        {
            return RedirectToAction("View", "Patient", new { id = diagnosticViewModel.SelectedPatientId });
        }

        [HttpPost]
        public IActionResult AddPatient()
        {
            return RedirectToAction("Add", "Patient");
        }

        [HttpPost]
        public IActionResult Diagnose(DiagnosticViewModel diagnosticViewModel)
        {
            KNN knn = new();
            string trainingFile = Path.Combine(Directory.GetCurrentDirectory(), "Data_HeartDiseaseDiagnostic", "train.csv");
            ConfigurationIa configurationIa = contextHelper.GetConfigurationIa();
            knn.Train(trainingFile, configurationIa.K, configurationIa.Distance);

            diagnosticViewModel.DiagnosticDB.Patient = context.Patients.Find(diagnosticViewModel.SelectedPatientId);
            diagnosticViewModel.DiagnosticDB.Target = knn.Predict(diagnosticViewModel.DiagnosticDB.ToDiagnostic());
            context.Diagnostics.Add(diagnosticViewModel.DiagnosticDB);
            context.SaveChanges();

            TempData["Result"] = "Résultat : " + (diagnosticViewModel.DiagnosticDB.Target ? "présence" : "absence") + " de maladie";
            return RedirectToAction("Index");
        }
    }
}
