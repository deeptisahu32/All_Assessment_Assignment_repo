using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API_1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        static List<string> str = new List<string>()
        {
            "value 1" ,"value 2","value 3","value 4"
        };
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return str;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return str[id-1];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            str.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            str[id - 1] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            str.RemoveAt(id - 1);
        }
    }
}
