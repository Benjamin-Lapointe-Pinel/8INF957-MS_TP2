using Microsoft.AspNetCore.Identity;
using RestApi.Models;

namespace RestApi.Services
{
    public class AuthenticationService
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        public static string HashPassword(string username, string password)
        {
            return passwordHasher.HashPassword(username, password);
        }

        public static bool VerifyHashedPassword(string username, string hashedPassword, string password)
        {
            return passwordHasher.VerifyHashedPassword(username, hashedPassword, password) == PasswordVerificationResult.Success;
        }
    }
}
