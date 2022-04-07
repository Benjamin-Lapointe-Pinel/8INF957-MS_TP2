using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi
{
    [Produces("application/json")]
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private TP2Context tp2Context;

        public PatientsController()
        {
            tp2Context = new TP2Context();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tp2Context.Patients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Patient? patient = tp2Context.Patients.Find(id);
                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PatientDTO patientDto)
        {
            try
            {
                Patient patient = new()
                {
                    FirstName = patientDto.FirstName,
                    LastName = patientDto.LastName,
                    Birthdate = patientDto.Birthdate,
                    Gender = patientDto.Gender,
                    City = patientDto.City
                };
                tp2Context.Patients.Add(patient);
                tp2Context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PatientDTO patientDto)
        {
            try
            {
                Patient? patient = tp2Context.Patients.Find(id);
                if (patient == null)
                {
                    return NotFound();
                }


                patient.FirstName = patientDto.FirstName;
                patient.LastName = patientDto.LastName;
                patient.Birthdate = patientDto.Birthdate;
                patient.Gender = patientDto.Gender;
                patient.City = patientDto.City;
                tp2Context.SaveChanges();
                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Patient? patient = tp2Context.Patients.Find(id);
                if (patient == null)
                {
                    return NotFound();
                }

                tp2Context.Patients.Remove(patient);
                tp2Context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
