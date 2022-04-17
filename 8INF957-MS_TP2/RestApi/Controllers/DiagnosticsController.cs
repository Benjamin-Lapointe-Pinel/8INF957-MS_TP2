#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/diagnostics")]
    [ApiController]
    public class DiagnosticsController : ControllerBase
    {
        private readonly TP2Context tp2Context;

        public DiagnosticsController()
        {
            tp2Context = new TP2Context();
        }

        private DiagnosticDB getContextDiagnostics(int id)
        {
            int doctorId = int.Parse(HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
            return tp2Context.Diagnostics.Include("Patient").Where(d => d.Patient.DoctorId == doctorId && d.Id == id).SingleOrDefault();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DiagnosticDB diagnostic = getContextDiagnostics(id);
                if (diagnostic == null)
                {
                    return NotFound();
                }

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

        [HttpDelete("{id}")]
        public IActionResult DeleteDiagnosticDB(int id)
        {
            try
            {
                DiagnosticDB diagnostic = getContextDiagnostics(id);
                if (diagnostic == null)
                {
                    return NotFound();
                }

                tp2Context.Diagnostics.Remove(diagnostic);
                tp2Context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
