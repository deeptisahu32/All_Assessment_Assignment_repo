using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Custom_Validation_Prj.CustomValidations
{
    public class ValidDOJ :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime entered_dob = Convert.ToDateTime(value);
            DateTime todaydate = Convert.ToDateTime(DateTime.Today);
            if (entered_dob <= todaydate)
            {
                return true;
            }
            else
                return false;

        }
    }
}