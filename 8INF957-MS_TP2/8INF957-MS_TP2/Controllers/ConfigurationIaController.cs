using _8INF957_MS_TP2.Services;
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
            return View(contextHelper.GetConfigurationIa());
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
                ConfigurationIa configurationIa = contextHelper.GetConfigurationIa();
                configurationIa.K = formConfigurationIa.K;
                configurationIa.Distance = formConfigurationIa.Distance;
                context.SaveChanges();
                return View("Index");
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
