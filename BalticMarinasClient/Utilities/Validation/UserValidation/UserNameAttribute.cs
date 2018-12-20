using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Utilities.Validation.UserValidation
{
    public class UserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string userName = value.ToString();

            if (UserUtilities.IsLengthValid50(value, validationContext) == false)
            {
                return new ValidationResult("Max length is 50");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
