using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Custom_Validation_Prj.CustomValidations
{
    public class validatepassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = Convert.ToString(value);

            // Check for null or empty
            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult(ErrorMessage ?? "Password cannot be empty.");
            }

            // Check length
            if (password.Length != 8)
            {
                return new ValidationResult(ErrorMessage);
            }

            // First character must be uppercase
            if (!char.IsUpper(password[0]))
            {
                return new ValidationResult(ErrorMessage ?? "First character must be an uppercase letter.");
            }

            // Second character must be a digit
            if (!char.IsDigit(password[1]))
            {
                return new ValidationResult(ErrorMessage ?? "Second character must be a digit.");
            }

            // Last 6 characters must be letters only
            for (int i = 2; i < 8; i++)
            {
                if (!char.IsLetter(password[i]))
                {
                    return new ValidationResult(ErrorMessage ?? "Last 6 characters must be letters only (A–Z or a–z).");
                }
            }

            return ValidationResult.Success;

        }
    }
}