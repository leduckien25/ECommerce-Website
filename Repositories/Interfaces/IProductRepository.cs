using WebApplicationMvc.Models;

namespace WebApplicationMvc.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsWithDetails();
        IEnumerable<Product> GetProductsWithDetails(out int pages, int page, int size = 12);
        Product? GetProduct(int id);
        Product? GetProductWithDetails(int id);
        IEnumerable<Product> GetProductsRelation(int id);
        IEnumerable<Product> GetProductsByCategory(short id);
        int GetProductsCount();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
