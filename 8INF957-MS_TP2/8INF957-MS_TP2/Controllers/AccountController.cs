using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RestApi;
using RestApi.Models;
using RestApi.Services;

namespace _8INF957_MS_TP2.Controllers
{
    public class AccountController : Controller
    {
        private TP2Context context;

        public AccountController(TP2Context tp2Context)
        {
            context = tp2Context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password, string ReturnUrl)
        {
            Doctor? doctor = context.Doctors.SingleOrDefault(u => u.Username == userName);
            if (doctor == null || !RestApi.Services.AuthenticationService.VerifyHashedPassword(userName, doctor.Password, password))
            {
                return View();
            }

            Claim[] claim = new[] { new Claim("DoctorId", doctor.Id.ToString()) };
            ClaimsIdentity identity = new(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity)).Wait();

            return Redirect(ReturnUrl == null ? "/Secured" : ReturnUrl);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
    }
}
