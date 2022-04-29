using KnnLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using RestApi.Models;
using RestApi.Models.DTO;

namespace RestApi
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly TP2Context tp2Context;

        public PatientsController()
        {
            tp2Context = new TP2Context();
        }

        private int GetContextDoctorId()
        {
            return int.Parse(HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
        }

        private List<Patient> GetContextDoctorPatients()
        {
            
            return tp2Context.Patients.Where(p => p.DoctorId == GetContextDoctorId()).ToList();
        }

        private Patient? GetContextDoctorPatient(int id)
        {
            return GetContextDoctorPatients().Where(p => p.Id == id).SingleOrDefault();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetContextDoctorPatients());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Patient? patient = GetContextDoctorPatient(id);
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
            int doctorId = int.Parse(HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
            Doctor? doctor = tp2Context.Doctors.Find(doctorId);
            if (doctor == null || patientDto.MissingFields)
            {
                return BadRequest();
            }
            try
            {
                Patient patient = new()
                {
                    FirstName = patientDto.FirstName,
                    LastName = patientDto.LastName,
                    Birthdate = patientDto.Birthdate,
                    Gender = patientDto.Gender,
                    City = patientDto.City,
                    DoctorId = doctor.Id,
                    Doctor = doctor
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
                Patient? patient = GetContextDoctorPatient(id);
                if (patient == null || patientDto.MissingFields)
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
                Patient? patient = GetContextDoctorPatient(id);
                if (patient == null)
                {
                    return NotFound();
                }

                tp2Context.Patients.Remove(patient);
                tp2Context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/diagnostics")]
        public IActionResult GetDiagnostics(int id)
        {
            try
            {
                int doctorId = int.Parse(HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
                Patient? patient = tp2Context.Patients.Include("DiagnosticDBs").SingleOrDefault(p => p.Id == id && p.DoctorId == doctorId);
                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(patient.DiagnosticDBs?.Select(d => new { d.Id, d.CP, d.CA, d.OldPeak, d.Thal, d.Target }));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("{id}/diagnose")]
        public IActionResult Diagnose(int id, [FromBody] DiagnosticDTO diagnosticDTO)
        {
            try
            {
                Patient? patient = GetContextDoctorPatient(id);
                if (patient == null)
                {
                    return NotFound();
                }

                DiagnosticDB diagnostic = new()
                {
                    CP = diagnosticDTO.CP,
                    CA = diagnosticDTO.CA,
                    OldPeak = diagnosticDTO.OldPeak,
                    Thal = diagnosticDTO.Thal,
                    Patient = patient,
                };

                KNN knn = new();
                string trainingFile = Path.Combine(Directory.GetCurrentDirectory(), "Data_HeartDiseaseDiagnostic", "train.csv");
                ConfigurationIa configurationIa = tp2Context.ConfigurationsIa.Single(c => c.DoctorId == GetContextDoctorId());
                knn.Train(trainingFile, configurationIa.K, configurationIa.Distance);
                diagnostic.Target = knn.Predict(diagnostic.ToDiagnostic());

                tp2Context.Diagnostics.Add(diagnostic);
                tp2Context.SaveChanges();
                return Ok(new
                {
                    diagnostic.Id,
                    diagnostic.CP,
                    diagnostic.CA,
                    diagnostic.OldPeak,
                    diagnostic.Thal,
                    diagnostic.Target,
                    patientId = diagnostic.Patient.Id
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
