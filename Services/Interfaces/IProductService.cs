using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts(int pageSize, int page, out int pages);

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

        IEnumerable<ProductViewModel> GetRelatedProducts(
            int productId,
            int pageSize,
            int page,
            out int pages
        );
    }
}
