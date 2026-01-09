using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AJAX_POSTING_PRJ.Models
{
    public class Student
    {
        [Key]
        public int stuid { get; set; }
        [Required]
        public string studentname { get; set; }
        [Required]
        public string studnetAddress {  get; set; }
    }
}