using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BalticMarinasClient.Utilities.Validation.UserValidation
{
    public class UserUtilities
    {
        public static bool IsLengthValid50(object value, ValidationContext validationContext)
        {
            string userName = value.ToString();

            if (userName.Length > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsLengthValid100(object value, ValidationContext validationContext)
        {
            string userName = value.ToString();

            if (userName.Length > 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ContainsNumbers(object value, ValidationContext validationContext)
        {
            string userPassword = value.ToString();
            bool areNumbers = Regex.IsMatch(userPassword, @"^[^0-9]+$");

            if (areNumbers == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsEmail(object value, ValidationContext validationContext)
        {
            string email = value.ToString();
            bool areNumbers = email.Contains("@");

            if (areNumbers == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
