
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using MVC_Client.Models;

namespace MVC_Client.Controllers
{
    public class OrdersController : Controller
    {
        // GET: /Orders/Buchanan
        public ActionResult Buchanan()
        {
            IEnumerable<MVCOrder> orders = null;

            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://localhost:44381/api/"); // <-- YOUR API URL
                var task = http.GetAsync("Orders/ByEmployee/5");            // api/Orders/ByEmployee/5
                task.Wait();

                var res = task.Result;
                if (res.IsSuccessStatusCode)
                {
                    var json = res.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<MVCOrder>>(json);
                }
                else
                {
                    orders = Enumerable.Empty<MVCOrder>();
                    ViewBag.Error = $"API Error: {res.StatusCode}";
                }
            }

            return View(orders);
        }
    }   
}
