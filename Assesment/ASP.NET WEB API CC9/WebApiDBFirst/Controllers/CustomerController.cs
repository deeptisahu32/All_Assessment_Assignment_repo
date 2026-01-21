using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDBFirst.Models;

namespace WebApiDBFirst.Controllers
{
    public class CustomerController : ApiController
    {
        private NorthwindMiniEntities1 db = new NorthwindMiniEntities1();

        // GET: api/Customers/ByCountry/UK
        [HttpGet]
        [Route("api/Customers/ByCountry/{country}")]
        [ResponseType(typeof(IQueryable<object>))]
        public IHttpActionResult ByCountry(string country)
        {
            // Function Import call (works whether it returns Complex Type or Customer entity)
            var data = db.GetCustomersByCountry(country)
                         .Select(c => new
                         {
                             c.CustomerID,
                             c.CompanyName,
                             c.ContactName,
                             c.Country
                         });

            if (!data.Any()) return NotFound();
            return Ok(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
