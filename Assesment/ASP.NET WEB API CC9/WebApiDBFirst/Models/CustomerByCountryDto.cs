using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDBFirst.Models
{
    public class CustomerByCountryDto
    {

        public string CustomerID { get; set; }   
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }

    }
}