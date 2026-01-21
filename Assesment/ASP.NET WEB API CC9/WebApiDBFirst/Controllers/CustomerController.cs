using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDBFirst.Models;

namespace WebApiDBFirst.Controllers
{
    public class CustomersController : ApiController
    {
        private NorthwindMiniEntities1 db = new NorthwindMiniEntities1();

        [HttpGet]
        [Route("api/customers/by-country/{country}")]
        [ResponseType(typeof(object))]
        public IHttpActionResult GetByCountry(string country)
        {
           
            var result = db.GetCustomersByCountry(country);
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
