using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
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
        private IConfiguration configuration;
        private TP2Context tp2Context;
        private AuthenticationService authenticationService;

        public LoginController(IConfiguration configuration, TP2Context tp2Context)
        {
            this.configuration = configuration;
            this.tp2Context = tp2Context;
            authenticationService = new AuthenticationService();
        }

        // https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDTO loginRequest)
        {
            Doctor? doctor = tp2Context.Doctors.SingleOrDefault(u => u.Username == loginRequest.Username);
            if (doctor == null || !authenticationService.VerifyHashedPassword(loginRequest.Username, doctor.Password, loginRequest.Password))
            {
                return Unauthorized("Invalid credentials");
            }

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("DoctorId", doctor.Id.ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
