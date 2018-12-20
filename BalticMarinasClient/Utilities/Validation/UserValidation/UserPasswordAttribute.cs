using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Utilities.Validation.UserValidation
{
    public class UserPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (UserUtilities.IsLengthValid50(value, validationContext) == false && UserUtilities.ContainsNumbers(value, validationContext) == false)
            {
                return new ValidationResult("Numeric values required and Max length is 50");
            }
            else if (UserUtilities.IsLengthValid50(value, validationContext) == false)
            {
                return new ValidationResult("Max length is 50");
            }
            else if (UserUtilities.ContainsNumbers(value, validationContext) == false)
            {
                return new ValidationResult("Numeric values required");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
