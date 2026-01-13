using MVC_DataBaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DataBaseFirst.Models;

namespace MVC_DataBaseFirst.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities db=new northwindEntities();   // this is my dbcotext

        // return all customer residing in german
        //Get
        public ActionResult germancustomer()
        {
            
           var customersInGermany = (from c in db.Customers
                                     where c.Country == "Germany"
                                      orderby c.CompanyName
                                       select c).ToList();
            return View(customersInGermany);
        }

        //Get
        // 2) Return customer details with orderId == 10248
        public ActionResult CustomerByOrder(int id = 10248)
        {

            var model = (from o in db.Orders
                         where o.OrderID == id
                         select new CustomerOrderVM
                         { 
                             OrderId=o.OrderID,

                             OrderDate = o.OrderDate,

                             CustomerId = o.CustomerID,
                             CompanyName = o.Customer.CompanyName,
                             ContactName = o.Customer.ContactName,
                             Phone = o.Customer.Phone,
                             Address = o.Customer.Address,
                             City = o.Customer.City,
                             Country = o.Customer.Country,


                             Lines = o.Order_Details.Select(od => new OrderLineVM
                             {
                                 ProductId = od.ProductID,
                                 ProductName = od.Product.ProductName,
                                 UnitPrice = od.UnitPrice,
                                 Quantity = od.Quantity,
                                 Discount = od.Discount,
                                 LineTotal = od.UnitPrice * od.Quantity * (1 - (int)od.Discount)
                             }).ToList()


                         }).FirstOrDefault();


            if (model == null)
            {
                return HttpNotFound($"Order {id} not found.");
            }
          return View(model);
        }

    }
    
}