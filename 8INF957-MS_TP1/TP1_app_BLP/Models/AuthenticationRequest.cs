using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_app_BLP.Models
{
    public class AuthenticationRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool IsValid => !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
    }
}
