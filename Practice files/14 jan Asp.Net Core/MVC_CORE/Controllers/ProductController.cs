using Microsoft.AspNetCore.Mvc;
using MVC_CORE.Services;

namespace MVC_CORE.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }
        public IActionResult index()
        {
            var productdetails = _productService.GetAllProducts();

            return View(productdetails);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product); // Pass a single Product
        }

    }
}
