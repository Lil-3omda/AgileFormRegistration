using AgileForm.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace AgileForm.Models.ViewModel
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="MaxLength of Name is 50")]
        [MinLength(3,ErrorMessage ="Minimum Length is 3")]
        public string? Name { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        //[Unique]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,32}$",
    ErrorMessage = "Password must be 8-32 characters and include at least one uppercase letter, one digit, and one special character.")]

        public string Password { get; set; }
    }
}
