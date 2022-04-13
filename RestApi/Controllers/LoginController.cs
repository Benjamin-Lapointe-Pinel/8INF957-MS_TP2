using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestApi.Models;
using RestApi.Models.DTO;
using RestApi.Services;

namespace RestApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private TP2Context tp2Context;
        private AuthenticationService authenticationService;

        public LoginController()
        {
            tp2Context = new TP2Context();
            authenticationService = new AuthenticationService();
        }

        // https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/
        [HttpPost("login")]
        [HttpPost]
        public IActionResult Login(LoginRequestDTO loginRequest)
        {
            Doctor doctor = tp2Context.Doctors.SingleOrDefault(u => u.Username == loginRequest.Username);
            if (doctor == null || !authenticationService.VerifyHashedPassword(loginRequest.Username, doctor.Password, loginRequest.Password))
            {
                return Unauthorized("Invalid credentials");
            }

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, "JWTServiceAccessToken"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", doctor.Id.ToString()),
                    new Claim("DisplayName", doctor.ToString()),
                    new Claim("UserName", doctor.Username),
                    new Claim("Email", doctor.Email)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                "JWTAuthenticationServer",
                "JWTServicePostmanClient",
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
