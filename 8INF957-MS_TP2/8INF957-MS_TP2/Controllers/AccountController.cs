using System.Security.Claims;
using _8INF957_MS_TP2.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi;
using RestApi.Models;
using RestApi.Services;

namespace _8INF957_MS_TP2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private TP2Context context;
        private ContextHelper contextHelper;

        public AccountController(TP2Context tp2Context)
        {
            context = tp2Context;
            contextHelper = new(this, tp2Context);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string userName, string password, string ReturnUrl)
        {
            Doctor? doctor = context.Doctors.SingleOrDefault(u => u.Username == userName);
            if (doctor == null || !RestApi.Services.AuthenticationService.VerifyHashedPassword(userName, doctor.Password, password))
            {
                ViewBag.Error = "Informations de connexion invalides";
                return View();
            }

            Claim[] claim = new[] { new Claim("DoctorId", doctor.Id.ToString()) };
            ClaimsIdentity identity = new(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity)).Wait();

            return Redirect(ReturnUrl == null ? "/Account/Informations" : ReturnUrl);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Informations()
        {
            Doctor? doctor = contextHelper.GetDoctor();
            if (doctor == null)
            {
                return RedirectToAction("Login");
            }
            return View(doctor);
        }

        [HttpPost]
        public IActionResult UpdateInformations(Doctor formDoctor)
        {
            try
            {
                Doctor? doctor = contextHelper.GetDoctor();
                if (doctor == null)
                {
                    return RedirectToAction("Login");
                }

                doctor.FirstName = formDoctor.FirstName;
                doctor.LastName = formDoctor.LastName;
                doctor.Birthdate = formDoctor.Birthdate;
                doctor.Gender = formDoctor.Gender;
                doctor.City = formDoctor.City;
                doctor.DateEntryOffice = formDoctor.DateEntryOffice;
                doctor.Email = formDoctor.Email;
                context.SaveChanges();
                return View("Informations");
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [AllowAnonymous]
        public IActionResult NewAccount()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult NewAccount(Doctor doctor)
        {
            if (context.Doctors.Any(d => d.Username == doctor.Username))
            {
                ViewBag.Error = "Ce nom d'utilisateur existe déjà";
                return View();
            }

            doctor.Password = RestApi.Services.AuthenticationService.HashPassword(doctor.Username, doctor.Password);
            context.Doctors.Add(doctor);
            context.SaveChanges();

            return View("Login");
        }
    }
}
