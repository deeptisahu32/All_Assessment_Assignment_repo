using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_MVC_Client.Models;

namespace Web_MVC_Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayProducts()
        {
            IEnumerable<MVCProduct> productslist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44302/api/");
                var responsetalk = webclient.GetAsync("product");
                responsetalk.Wait();

                var result = responsetalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    productslist = JsonConvert.DeserializeObject<List<MVCProduct>>(resultdata);
                }
                else
                {
                    productslist = Enumerable.Empty<MVCProduct>();
                }
                return View(productslist);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MVCProduct mvcproduct)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44302/api/");
                var posttalk = webclient.PostAsJsonAsync<MVCProduct>("Product", mvcproduct);
                posttalk.Wait();
                var dataresult = posttalk.Result;

                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("DisplayProducts");
                }
                ModelState.AddModelError(String.Empty, "Insertion Failed , try again later");
                return View(mvcproduct);
            }
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MVCProduct product = null;

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44302/api/");
                var edittalk = await webclient.GetAsync($"product/{id}");

                if (edittalk.IsSuccessStatusCode)
                {
                    var resultdata = await edittalk.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<MVCProduct>(resultdata);
                }
                else if (edittalk.StatusCode == HttpStatusCode.NotFound)
                {
                    return HttpNotFound();
                }
                else
                {
                    ModelState.AddModelError("", "Some Error Occurred.");
                }
            }

            if (product == null)
                return HttpNotFound();

            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MVCProduct p)
        {
            if (!ModelState.IsValid)
                return View(p); // stay on edit if validation failed

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44302/api/");

                // IMPORTANT: include the id in the URL
                var response = await webclient.PutAsJsonAsync($"product/{p.ID}", p);
                // If your model uses p.Id, use $"product/{p.Id}"

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("DisplayProducts");
                }

                // Show server error message on the same page
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Update failed. Server said: {error}");
                return View(p); // do NOT redirect here
            }
        }




        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MVCProduct product = null;

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44302/");

                var response = webclient.GetAsync("api/Product/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var resultdata = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<MVCProduct>(resultdata);
                }
            }

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44302/");

                var response = webclient.DeleteAsync("api/Product/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("DisplayProducts");
                }
            }

            return RedirectToAction("DisplayProducts");
        }

    }

}