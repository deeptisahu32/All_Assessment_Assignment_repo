using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVC_CODE_FIRST.Models
{
    public class Movie
    {

        [Key]
        public int Mid { get; set; }

        [Required, StringLength(200)]
        public string MovieName { get; set; }

        [Required, StringLength(200)]
        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Release")]
        public DateTime DateOfRelease { get; set; }

    }
}