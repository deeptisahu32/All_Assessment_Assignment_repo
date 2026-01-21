using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api_Assessments.Models;

namespace Web_Api_Assessments.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>
       {
        new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
        new Country { ID = 2, CountryName = "USA", Capital = "Washington D.C." },
        new Country { ID = 3, CountryName = "Sri Lanka", Capital = "Sri Jayawardenepura Kotte" },
        new Country { ID = 4, CountryName = "Bhutan", Capital = "Thimphu" },
        new Country { ID = 5, CountryName = "China", Capital = "Beijing" },
        new Country { ID = 6, CountryName = "Japan", Capital = "Tokyo" },
        new Country { ID = 7, CountryName = "Rassia", Capital = "Moscow" },
        new Country { ID = 8, CountryName = "Canada", Capital = "Ottawa" },
        new Country { ID = 9, CountryName = "United Kingdom", Capital = "London" },
        new Country { ID = 10, CountryName = "Spain", Capital = "Madrid" }

       };
        [HttpGet]
        [Route("All Country")]
        public IEnumerable<Country> Get()
        {
            return countrylist;
        }

        [HttpGet]
        [Route("country by msg")]
        public HttpResponseMessage ShowAllMsg()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
            return response;
        }

        // GET
        public IHttpActionResult Get(int id)
        {
            var country = countrylist.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        // POST
        public IHttpActionResult Post(Country country)
        {
            countrylist.Add(country);
            return Created($"api/Country/{country.ID}", country);
        }

        // PUT
        public IHttpActionResult Put(int id, Country country)
        {
            var existing = countrylist.FirstOrDefault(c => c.ID == id);
            if (existing == null) return NotFound();
            existing.CountryName = country.CountryName;
            existing.Capital = country.Capital;
            return Ok(existing);
        }

        // DELETE
        public IHttpActionResult Delete(int id)
        {
            var country = countrylist.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();
            countrylist.Remove(country);
            return Ok();
        }
    }
}
