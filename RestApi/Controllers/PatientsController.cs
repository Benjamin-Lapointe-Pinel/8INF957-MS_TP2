using KnnLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Models.DTO;

namespace RestApi
{
    [Produces("application/json")]
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly TP2Context tp2Context;
        private readonly KNN knn;

        public PatientsController()
        {
            tp2Context = new TP2Context();
            knn = new KNN();
            string trainingFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Data_HeartDiseaseDiagnostic", "train.csv");
            knn.Train(trainingFile, 6, "euclidean");
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
                Patient? patient = tp2Context.Patients.Include("DiagnosticDBs").SingleOrDefault(x => x.Id == id);

                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(patient.DiagnosticDBs?.Select(d => new { d.CP, d.CA, d.OldPeak, d.Thal, d.Target }));
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
                Patient? patient = tp2Context.Patients.Find(id);

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
                diagnostic.Target = knn.Predict(diagnostic);

                tp2Context.Diagnostics.Add(diagnostic);
                tp2Context.SaveChanges();
                return Ok(new
                {
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
