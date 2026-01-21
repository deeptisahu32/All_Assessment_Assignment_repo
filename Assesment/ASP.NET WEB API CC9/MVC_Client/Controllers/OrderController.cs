using MVC_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace MVC_Client.Controllers
{
    public class OrderController : Controller
    {
        // GET: /Orders
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Orders/DisplayOrdersOfBuchanan
        public ActionResult DisplayOrdersOfBuchanan()
        {
            IEnumerable<MVCOrder> orders = null;

            using (var client = new HttpClient())
            {
                var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
                if (string.IsNullOrWhiteSpace(baseUrl))
                {
                    baseUrl = "https://localhost:44381/api/";
                }

                client.BaseAddress = new Uri(baseUrl);

                // Matches API route: GET api/orders/employee/5
                var responseTask = client.GetAsync("orders/employee/5");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<MVCOrder>>(json);
                }
                else
                {
                    orders = Enumerable.Empty<MVCOrder>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(orders);
        }
    }
}
