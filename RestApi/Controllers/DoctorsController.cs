using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestApi.Models;
using RestApi.Models.DTO;
using RestApi.Services;

namespace RestApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/info")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private IConfiguration configuration;
        private TP2Context tp2Context;

        public DoctorsController(IConfiguration configuration, TP2Context tp2Context)
        {
            this.configuration = configuration;
            this.tp2Context = tp2Context;
        }

        private Doctor? getContextDoctor()
        {
            int doctorId = int.Parse(HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
            return tp2Context.Doctors.Find(doctorId);
        }

        // https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDTO loginRequest)
        {
            Doctor? doctor = tp2Context.Doctors.SingleOrDefault(u => u.Username == loginRequest.Username);
            if (doctor == null || !AuthenticationService.VerifyHashedPassword(loginRequest.Username, doctor.Password, loginRequest.Password))
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

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            Doctor? doctor = getContextDoctor();
            if (doctor == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                doctor.FirstName,
                doctor.LastName,
                doctor.Birthdate,
                doctor.Gender,
                doctor.City,
                doctor.DateEntryOffice,
                doctor.Email
            });
        }

        [HttpPut("info")]
        public IActionResult PutInfo([FromBody] DoctorDTO doctorDto)
        {
            try
            {
                Doctor? doctor = getContextDoctor();
                if (doctor == null || doctorDto.MissingFields)
                {
                    return BadRequest();
                }

                doctor.FirstName = doctorDto.FirstName;
                doctor.LastName = doctorDto.LastName;
                doctor.Birthdate = doctorDto.Birthdate;
                doctor.Gender = doctorDto.Gender;
                doctor.City = doctorDto.City;
                doctor.DateEntryOffice = doctorDto.DateEntryOffice;
                doctor.Email = doctorDto.Email;
                tp2Context.SaveChanges();
                return Ok(new
                {
                    doctor.FirstName,
                    doctor.LastName,
                    doctor.Birthdate,
                    doctor.Gender,
                    doctor.City,
                    doctor.DateEntryOffice,
                    doctor.Email
                });

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("info")]
        public IActionResult PatchInfo([FromBody] DoctorDTO doctorDto)
        {
            try
            {
                Doctor? doctor = getContextDoctor();
                if (doctor == null)
                {
                    return BadRequest();
                }

                doctor.FirstName = doctorDto.FirstName ?? doctor.FirstName;
                doctor.LastName = doctorDto.LastName ?? doctor.LastName;
                doctor.Birthdate = doctorDto.Birthdate;
                doctor.Gender = doctorDto.Gender;
                doctor.City = doctorDto.City ?? doctor.City;
                doctor.DateEntryOffice = doctorDto.DateEntryOffice;
                doctor.Email = doctorDto.Email ?? doctor.Email;
                tp2Context.SaveChanges();
                return Ok(new
                {
                    doctor.FirstName,
                    doctor.LastName,
                    doctor.Birthdate,
                    doctor.Gender,
                    doctor.City,
                    doctor.DateEntryOffice,
                    doctor.Email
                });

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
