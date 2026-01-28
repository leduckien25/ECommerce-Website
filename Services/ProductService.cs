using AutoMapper;
using WebApplicationMvc.Services.Interfaces;
using WebApplicationMvc.UnitOfWork;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ProductViewModel? GetProduct(int id)
        {
            var product = _uow.Product.GetProductWithDetails(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductViewModel>(product);
        }

        public IEnumerable<ProductViewModel> GetProducts(int pageSize, int page, out int pages)
        {
            var products = _uow.Product.GetProductsWithDetails(out pages, page, pageSize);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public IEnumerable<ProductViewModel> GetProductsByCategory(
            short categoryId, int pageSize, int page, out int pages)
        {
            var products = _uow.Product
                .GetProductsByCategory(categoryId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var total = _uow.Product.GetProductsByCategory(categoryId).Count();
            pages = (total - 1) / pageSize + 1;

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public IEnumerable<ProductViewModel> GetProductsBySupplier(
            string supplierId, int pageSize, int page, out int pages)
        {
            var products = _uow.Product
                .GetProductsBySupplier(supplierId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var total = _uow.Product.GetProductsBySupplier(supplierId).Count();
            pages = (total - 1) / pageSize + 1;

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public IEnumerable<ProductViewModel> GetRelatedProducts(
            int productId, int pageSize)
        {
            var products = _uow.Product.GetProductsRelation(productId);

            return _mapper.Map<IEnumerable<ProductViewModel>>(
                products.Take(pageSize)
            );
        }
    }
}
