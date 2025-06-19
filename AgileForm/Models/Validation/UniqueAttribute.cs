using AgileForm.Models.Context;
using AgileForm.Repository;
using System.ComponentModel.DataAnnotations;

namespace AgileForm.Models.Validation
{
    public class UniqueAttribute:ValidationAttribute
    {
        UserRepository _user;
        public UniqueAttribute()
        {
            _user = new UserRepository();
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = value?.ToString();


            if (_user.GetByEmail(email) != null)
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
