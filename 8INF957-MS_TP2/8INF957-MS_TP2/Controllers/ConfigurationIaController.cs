using _8INF957_MS_TP2.Services;
using KnnLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi;
using RestApi.Models;

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class ConfigurationIaController : Controller
    {
        private TP2Context context;
        private ContextHelper contextHelper;

        public ConfigurationIaController(TP2Context tp2Context)
        {
            context = tp2Context;
            contextHelper = new(this, tp2Context);
        }

        public IActionResult Index()
        {
            return View(contextHelper.GetConfigurationIa() ?? new ConfigurationIa());
        }

        [HttpPost]
        public IActionResult Index(ConfigurationIa formConfigurationIa)
        {
            if (formConfigurationIa.K <= 0)
            {
                ViewBag.Error = "K doit être un entier positif";
                return View();
            }
            if (formConfigurationIa.Distance != "manhattan" && formConfigurationIa.Distance != "euclidean")
            {
                ViewBag.Error = "La distance doit être Manhattan ou Euclidienne";
                return View();
            }

            try
            {
                ConfigurationIa configurationIa = contextHelper.GetConfigurationIa() ?? formConfigurationIa;
                configurationIa.K = formConfigurationIa.K;
                configurationIa.Distance = formConfigurationIa.Distance;
                configurationIa.DoctorId = contextHelper.GetDoctorId();
                context.ConfigurationsIa.Update(configurationIa);
                context.SaveChanges();

                KNN knn = new();
                string trainingFile = Path.Combine(Directory.GetCurrentDirectory(), "Data_HeartDiseaseDiagnostic", "train.csv");
                string samplesFile = Path.Combine(Directory.GetCurrentDirectory(), "Data_HeartDiseaseDiagnostic", "samples.csv");
                knn.Train(trainingFile, configurationIa.K, configurationIa.Distance);
                knn.Evaluate(samplesFile);

                ViewBag.AccuracyMessage = $"Taux de reconnaissance : {knn.Accuracy} %";
                return View("Index");
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
