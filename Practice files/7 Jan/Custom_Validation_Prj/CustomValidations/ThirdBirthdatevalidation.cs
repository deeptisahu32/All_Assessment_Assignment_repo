using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Custom_Validation_Prj.CustomValidations
{
    public class ThirdBirthdatevalidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
                return new ValidationResult("Date of Birth is required.");

            DateTime dob;
            if (!DateTime.TryParse(value.ToString(), out dob))
                return new ValidationResult("Invalid Date of Birth format.");

            int age = CalculateAge(dob);
            if (age < 21 || age > 25)
                return new ValidationResult("Age must be between 21 and 25 years.");

            return ValidationResult.Success;
        }

        private int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }

    }
}