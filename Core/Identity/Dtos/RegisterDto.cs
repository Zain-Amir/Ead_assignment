
using System.ComponentModel.DataAnnotations;

namespace BEN.DTOs
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }

        private string Gender = "Male";
    }

   
}
