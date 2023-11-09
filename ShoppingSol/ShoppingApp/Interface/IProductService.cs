using ShoppingApp.Models;

namespace ShoppingApp.Interface
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product Add(Product product);
    }
}
