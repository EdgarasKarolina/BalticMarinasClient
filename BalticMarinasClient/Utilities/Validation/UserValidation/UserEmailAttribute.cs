using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Utilities.Validation.UserValidation
{
    public class UserEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (UserUtilities.IsLengthValid100(value, validationContext) == false && UserUtilities.IsEmail(value, validationContext) == false)
            {
                return new ValidationResult("Must be valid email and Max length is 100");
            }
            else if (UserUtilities.IsLengthValid100(value, validationContext) == false)
            {
                return new ValidationResult("Max length is 100");
            }
            else if (UserUtilities.ContainsNumbers(value, validationContext) == false)
            {
                return new ValidationResult("Must be valid email");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
