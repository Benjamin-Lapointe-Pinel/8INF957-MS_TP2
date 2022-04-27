using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestApi.Models;

namespace _8INF957_MS_TP2.Models
{
    public class DiagnostiqueViewModel
    {
        public DiagnostiqueViewModel(List<Patient> patients)
        {
            Patients = patients
                .Select(p => new SelectListItem() { Text = p.FirstName + " " + p.LastName, Value = p.Id.ToString() })
                .ToList();
        }

        public IEnumerable<SelectListItem> Patients { get; set; }

        [Display(Name = "Patient")]
        public int SelectedPatientId { get; set; }
    }
}
