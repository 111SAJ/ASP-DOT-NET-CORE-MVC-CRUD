using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string EmployeeEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public bool isLoggedIn { get; set; } = false;
    }
}
