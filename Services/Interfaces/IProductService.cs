using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts(int page, int pageSize);

        IEnumerable<ProductViewModel> GetProductsByCategory(
            short categoryId,
            int pageSize,
            int page,
            out int pages
        );

        IEnumerable<ProductViewModel> GetProductsBySupplier(
            string supplierId,
            int pageSize,
            int page,
            out int pages
        );

        ProductViewModel? GetProduct(int id);

        IEnumerable<ProductViewModel> GetRelatedProducts(int productId, int pageSize);
        int GetProductsCount();
        IEnumerable<Product>? GetProductsWithDetails(int page, int pageSize = 12);
        int GetTotalPages(int pageSize = 12);
        Product? GetProductWithDetails(int id);
        bool UpdateProduct(Product product, IFormFile? file);
        bool AddProduct(Product product, IFormFile file);
        bool Delete(int id);
    }
}