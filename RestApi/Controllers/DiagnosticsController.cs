#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/diagnostics")]
    [ApiController]
    public class DiagnosticsController : ControllerBase
    {
        private readonly TP2Context tp2Context;

        public DiagnosticsController(TP2Context context)
        {
            tp2Context = context;
        }

        //// PUT: api/Diagnostics/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDiagnosticDB(int id, DiagnosticDB diagnosticDB)
        //{
        //    if (id != diagnosticDB.Id)
        //    {
        //        return BadRequest();
        //    }

        //    tp2Context.Entry(diagnosticDB).State = EntityState.Modified;

        //    try
        //    {
        //        await tp2Context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DiagnosticDBExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Diagnostics
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<DiagnosticDB>> PostDiagnosticDB(DiagnosticDB diagnosticDB)
        //{
        //    tp2Context.Diagnostics.Add(diagnosticDB);
        //    await tp2Context.SaveChangesAsync();

        //    return CreatedAtAction("GetDiagnosticDB", new { id = diagnosticDB.Id }, diagnosticDB);
        //}

        //// DELETE: api/Diagnostics/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDiagnosticDB(int id)
        //{
        //    var diagnosticDB = await tp2Context.Diagnostics.FindAsync(id);
        //    if (diagnosticDB == null)
        //    {
        //        return NotFound();
        //    }

        //    tp2Context.Diagnostics.Remove(diagnosticDB);
        //    await tp2Context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DiagnosticDBExists(int id)
        //{
        //    return tp2Context.Diagnostics.Any(e => e.Id == id);
        //}
    }
}
