using AgileForm.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace AgileForm.Models.Validation
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = value?.ToString();

            FormContext formContext = new FormContext();

            //User user = (User)validationContext.ObjectInstance;

            if (formContext.Users.FirstOrDefault(u => u.Email == email) == null)
            {
                return new ValidationResult("This Email is Exist");
            }
            else
            {
                return ValidationResult.Success;
            }


        }
    }
}
