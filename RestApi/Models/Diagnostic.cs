using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace RestApi.Models
{
    public class Diagnostic
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

            Label = diagnostic == 1;
        }

        public float[] Features { get; private set; }

        public bool Label { get; private set; }

        public override string ToString()
        {
            return $"chest pain : {Features[0]}, " +
                $"thalassemia : {Features[1]}, " +
                $"old peak : {Features[2]}, " +
                $"fluoroscopy : {Features[3]}, " +
                $"diagnostic : {Label}";
        }
    }
}
