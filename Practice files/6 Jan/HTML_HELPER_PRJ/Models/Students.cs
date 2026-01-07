using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HTML_HELPER_PRJ.Models
{
    public class Students
    {
        [Display(Name="Student Roll Number")]
        public int RNo { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address {  get; set; }
    }
}