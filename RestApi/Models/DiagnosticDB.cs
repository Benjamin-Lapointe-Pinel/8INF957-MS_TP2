using KnnLibrary;

namespace RestApi.Models
{
    public class DiagnosticDB : Diagnostic
    {
        public int Id { get; set; }
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
    }
}
