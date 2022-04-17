namespace RestApi.Models.DTO
{
    public class DoctorDTO : PersonDTO
    {
        public DateTime DateEntryOffice { get; set; }
        public string? Email { get; set; }

        public override bool MissingFields =>
            base.MissingFields ||
            DateEntryOffice == null ||
            string.IsNullOrEmpty(Email);

        public DoctorDTO(string firstName, string lastName, DateTime birthdate, Person.GenderEnum gender, string city, DateTime dateEntryOffice, string email)
            : base(firstName, lastName, birthdate, gender, city)
        {
            DateEntryOffice = dateEntryOffice;
            Email = email;
        }
    }
}