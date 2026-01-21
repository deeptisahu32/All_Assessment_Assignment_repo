using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class MVCOrder
    {

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCountry { get; set; }

    }
}