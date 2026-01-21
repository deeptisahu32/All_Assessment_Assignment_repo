using MVC_CORE.Models;

namespace MVC_CORE.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product ? GetProductById(int id);

    }
}
