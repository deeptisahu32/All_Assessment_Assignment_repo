
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using MVC_Client.Models;
namespace MVC_Client.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult ByCountry(string country = "UK")
        {
            ViewBag.Country = country;
            return View(new List<MVCCustomer>()); 
        }

        [HttpPost]
        public ActionResult ByCountryFetch(string country)
        {
            ViewBag.Country = country;
            IEnumerable<MVCCustomer> customers;

            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://localhost:44381/api/"); 
                var respTask = http.GetAsync($"Customers/ByCountry/{country}");
                respTask.Wait();

                var res = respTask.Result;
                if (res.IsSuccessStatusCode)
                {
                    var json = res.Content.ReadAsStringAsync().Result;
                    customers = JsonConvert.DeserializeObject<List<MVCCustomer>>(json);
                }
                else
                {
                    customers = Enumerable.Empty<MVCCustomer>();
                    ViewBag.Error = $"API Error: {res.StatusCode}";
                }
            }

            return View("ByCountry", customers); // reuse same view
        }
    }
}
