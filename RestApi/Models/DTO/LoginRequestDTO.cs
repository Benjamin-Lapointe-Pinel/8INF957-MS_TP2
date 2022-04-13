using System.ComponentModel.DataAnnotations;

namespace RestApi.Models.DTO
{
    public class LoginRequestDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
