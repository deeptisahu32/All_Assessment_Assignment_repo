using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Custom_Validation_Prj.CustomValidations
{
    public class BirthdateSecondValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateOfBirth=(DateTime)value;

            if (dateOfBirth.Year < 1998)
            {
                return new ValidationResult("Seems you are a bit old for this Job");
            }
            if(dateOfBirth.Year > 2004)
            {
                return new ValidationResult("Seems you are very young for this Job");
            }
            if(dateOfBirth.Month == 4)
            {
                return new ValidationResult("Sorry , we cannot accept April Borns");
            }
            return ValidationResult.Success;
        }
    }
}