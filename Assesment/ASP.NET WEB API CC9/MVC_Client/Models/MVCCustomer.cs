using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class MVCCustomer
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
    }
}