using System.ComponentModel.DataAnnotations;
using KnnLibrary;

namespace RestApi.Models
{
    public class DiagnosticDB
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public float CP { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public float CA { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public float OldPeak { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public float Thal { get; set; }
        public bool Target { get; set; }

        public Patient Patient { get; set; }

        public DiagnosticDB()
        {
        }

        public DiagnosticDB(int id, float cp, float ca, float oldPeak, float thal)
        {
            Id = id;
            CP = cp;
            CA = ca;
            OldPeak = oldPeak;
            Thal = thal;
        }

        public Diagnostic ToDiagnostic()
        {
            return new Diagnostic()
            {
                CP = CP,
                CA = CA,
                OldPeak = OldPeak,
                Thal = Thal,
                Target = Target
            };
        }
    }
}
