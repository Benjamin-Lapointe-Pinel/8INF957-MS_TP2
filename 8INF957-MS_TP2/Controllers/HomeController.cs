using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace _8INF957_MS_TP2.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Connexion()
        {
            return View();
        }

        public IActionResult Informations()

        {
            return View();
        }

        public IActionResult Diagnostique()
        {
            return View();
        }
        public IActionResult CreerCompte()
        {
            return View();
        }



    }
}