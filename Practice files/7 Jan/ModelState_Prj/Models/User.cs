using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ModelState_Prj.Models
{
    public class User
    {
        [Required(ErrorMessage ="First Name is needed")]
        [DisplayName("First Name")]
        [StringLength(30,ErrorMessage ="First Name cannot be more than 30 characters")]
        public string FName { get; set; }

        [DisplayName("Last Name")]
        public string Lname {  get; set; }

        [DisplayName("Users Age")]
        [Range(21, 45)]
        public int age {  get; set; }

        [Required(ErrorMessage ="Email must be there")]
        [EmailAddress]
        [DisplayName("Email ID")]
        public string Email { get; set; }


    }
}