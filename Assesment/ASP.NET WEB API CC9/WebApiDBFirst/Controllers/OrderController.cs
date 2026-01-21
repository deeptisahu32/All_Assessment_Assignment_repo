using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDBFirst.Models;

namespace WebApiDBFirst.Controllers
{
    public class OrdersController : ApiController
    {
        private NorthwindMiniEntities1 db = new NorthwindMiniEntities1();

        [HttpGet]
        [Route("api/orders/employee/{employeeId:int}")]
        [ResponseType(typeof(IQueryable<object>))]
        public IHttpActionResult GetOrdersByEmployee(int employeeId)
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == employeeId)
                           .OrderByDescending(o => o.OrderDate)
                           .Select(o => new  
                           {
                               o.OrderID,
                               o.CustomerID,
                               o.EmployeeID,
                               o.OrderDate,
                               o.ShipCountry,
                           });

            return Ok(orders);
        }
        [HttpGet]
        [Route("api/orders/buchanan")]
        [ResponseType(typeof(IQueryable<object>))]
        public IHttpActionResult GetBuchananOrders()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .OrderByDescending(o => o.OrderDate)
                           .Select(o => new
                           {
                               o.OrderID,
                               o.CustomerID,
                               o.EmployeeID,
                               o.OrderDate,
                               o.ShipCountry,
                           });

            return Ok(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
