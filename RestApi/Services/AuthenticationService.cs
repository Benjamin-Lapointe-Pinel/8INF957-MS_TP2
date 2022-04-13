using Microsoft.AspNetCore.Identity;
using RestApi.Models;

namespace RestApi.Services
{
    public class AuthenticationService
    {
        private PasswordHasher<string> passwordHasher;

        public AuthenticationService()
        {
            passwordHasher = new PasswordHasher<string>();
        }

        public string HashPassword(string username, string password)
        {
            return passwordHasher.HashPassword(username, password);
        }

        public bool VerifyHashedPassword(string username, string hashedPassword, string password)
        {
            return passwordHasher.VerifyHashedPassword(username, hashedPassword, password) == PasswordVerificationResult.Success;
        }
    }
}
