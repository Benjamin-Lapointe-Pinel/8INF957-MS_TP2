using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.Model
{
    public class Diagnostic : IDiagnostic
    {
        public Diagnostic(
            [Name("cp")] float chestPain,
            [Name("thal")] float thalassemia,
            [Name("oldpeak")] float oldPeak,
            [Name("ca")] float fluoroscopy,
            [Name("target")] float diagnostic = 0)
        {
            Features = new float[4];
            Features[0] = chestPain;
            Features[1] = thalassemia;
            Features[2] = oldPeak;
            Features[3] = fluoroscopy;

            Target = diagnostic == 1;
        }

        public float[] Features { get; private set; }
        public bool Target { get; set; }
        public float CP => Features[0];
        public float Thal => Features[1];
        public float OldPeak => Features[2];
        public float CA => Features[3];

        public void PrintInfo()
        {
            Console.Write(ToString());
        }

        public override string ToString()
        {
            return $"chest pain : {Features[0]}, " +
                $"thalassemia : {Features[1]}, " +
                $"old peak : {Features[2]}, " +
                $"fluoroscopy : {Features[3]}, " +
                $"diagnostic : {Target}";
        }
    }
}
