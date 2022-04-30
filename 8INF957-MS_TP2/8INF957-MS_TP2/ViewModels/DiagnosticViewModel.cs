using Microsoft.AspNetCore.Mvc.Rendering;
using RestApi.Models;

namespace _8INF957_MS_TP2.ViewModels
{
    public class DiagnosticViewModel
    {
        public List<SelectListItem>? Patients { get; set; }
        public int? SelectedPatientId { get; set; }
        public DiagnosticDB? DiagnosticDB { get; set; }

        public DiagnosticViewModel(List<Patient> patients)
        {
            Patients = patients.Select(p => new SelectListItem(p.ToString(), p.Id.ToString())).ToList();
        }

        public DiagnosticViewModel()
        {
        }
    }
}
