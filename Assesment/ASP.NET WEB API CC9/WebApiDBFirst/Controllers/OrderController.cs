using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDBFirst.Models;

namespace WebApiDBFirst.Controllers
{
    public class OrderController : ApiController
    {
        private NorthwindMiniEntities1 db = new NorthwindMiniEntities1();

        [HttpGet]
        [Route("api/Orders/ByEmployee/{employeeId:int}")]
        [ResponseType(typeof(IQueryable<Order>))]
        public IHttpActionResult GetByEmployee(int employeeId)
        {
            var orders = db.Orders.Where(o => o.EmployeeID == employeeId);
            if (!orders.Any()) return NotFound();
            return Ok(orders);
        }


        [HttpGet]
        [Route("api/Orders/Buchanan")]
        public IHttpActionResult GetBuchanan()
        {
            return GetByEmployee(5);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
