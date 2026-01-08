using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pratial_view_prj.Models;

namespace Pratial_view_prj.Controllers
{
    public class productController : Controller
    {
        List<products> products;
        public productController()
        {
            products = new List<products>()
            {
                new products{productid=1,productname="Shirt",category="Cloth",productdecription="comfort to wear",productprice=2000},
                new products{productid=2,productname="Shoes",category="Accesories",productdecription="smooth soles",productprice=3400},
                new products{productid=3,productname="Jeans",category="Cloth",productdecription="comfort to wear",productprice=4500},
                new products{productid=4,productname="Watch",category="Accessories",productdecription="quality good",productprice=2000},
                new products{productid=5,productname="curtains",category="Funrshings",productdecription="valence for windows",productprice=17000}
            };
        }
        // GET: product
        //public ActionResult Index()
        //{
        //    //List<products> products = new List<products>()
        //    //{
        //    //    new products{productid=1,productname="Shirt",category="Cloth",productdecription="comfort to wear",productprice=2000},
        //    //    new products{productid=2,productname="Shoes",category="Accesories",productdecription="smooth soles",productprice=3400},
        //    //    new products{productid=3,productname="Jeans",category="Cloth",productdecription="comfort to wear",productprice=4500},
        //    //    new products{productid=4,productname="Watch",category="Accessories",productdecription="quality good",productprice=2000},
        //    //    new products{productid=5,productname="curtains",category="Funrshings",productdecription="valence for windows",productprice=17000}
        //    //};
        //    return View(products);
        //}
        public ActionResult index1()
        {

            return View(products);
        }

        //2.partial view  (annther way)
        public PartialViewResult GetAllProduct()
        {
            return PartialView("productdetails",products);
        }
    }
}