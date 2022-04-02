using System.Diagnostics;
using _8INF957_MS_TP2.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public IActionResult ConfigurationIA()
        {
            return View();
        }
    }
}