using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class ConfigurationIa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public int K { get; set; } = 1;
        [Required(ErrorMessage = "Champ requis!")]
        public string Distance { get; set; } = "euclidean";
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        public ConfigurationIa() { }

        public ConfigurationIa(int k, string distance)
        {
            K = k;
            Distance = distance;
        }
    }
}
