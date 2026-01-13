using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DataBaseFirst.Models
{
    
        public class OrderLineVM
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public short Quantity { get; set; }
            public float Discount { get; set; }
            public decimal LineTotal { get; set; }
        }

        public class CustomerOrderVM
        {
            // Order 
            public int OrderId { get; set; }
            public DateTime? OrderDate { get; set; }

            // Customer 
            public string CustomerId { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }


           // Order lines
            public List<OrderLineVM> Lines { get; set; }


        }


}