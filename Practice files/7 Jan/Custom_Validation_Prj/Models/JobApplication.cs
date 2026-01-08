using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Custom_Validation_Prj.CustomValidations;

namespace Custom_Validation_Prj.Models
{
    public class JobApplication
    {
        [Required]
        [DisplayName("Applicant Name")]
        public string name { get; set; }

        [Display(Name = "Years of Experience")]
        [Range(3, 10, ErrorMessage = "Experience must be between 3 and 10 Years")]
        public int experience { get; set; }

        [DisplayName("DOB")]
        [DataType(DataType.Date)]
        [ThirdBirthdatevalidation(ErrorMessage = "Age must be between 21 and 25 years.")]
        [BirthdateSecondValidation]
        [ValidBirthDate(ErrorMessage = "DOB should be between 01/01/1998 and 31/12/2004 only")]
        public DateTime birthdate { get; set; }

        [Required]
        [Display(Name = "Email Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})$",
            ErrorMessage = "Invalid Email Format")]
        public string email { get; set; }
        [GenderValidate(ErrorMessage = "Please select your correct Gender")]
        public string Gender { get; set; }
        [DisplayName("Expected Salary")]
        [RegularExpression(@"^(0(?!\.00)|[1-9]\d{0,6})\.\d{2}$", ErrorMessage =
            "Salary should be like 60000.45")]
        public decimal expsal { get; set; }

        [SkillValidation(ErrorMessage ="Please select 3 or more skills")]
        public List<CheckBox> Skills { get; set; }


        [Required]
        public string HavePassport { get; set; }


        [DisplayName("DOJ")]
        [DataType(DataType.Date)]
        [ValidDOJ(ErrorMessage = "DOJ must be on or before today's date")]
        public DateTime DOJ { get; set; }



        [Required]
        [DisplayName("Password")]
        [validatepassword(ErrorMessage = "Password must be 8 characters: uppercase letter, then a number, followed by 6 letters (A–Z or a–z).")] 
        public string Password { get; set; }


    }
}