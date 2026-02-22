using WebApplicationMvc.Data;
using WebApplicationMvc.Repositories;
using WebApplicationMvc.Repositories.Interfaces;
using WebApplicationMvc.UnitOfWork;

namespace WebApplicationMvc.Providers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext context;

        public UnitOfWork(EcommerceDbContext context)
        {
            this.context = context;
        }

        private ICategoryRepository? category;
        public ICategoryRepository Category => category ??= new CategoryRepository(context);

        private ISupplierRepository? supplier;
        public ISupplierRepository Supplier => supplier ??= new SupplierRepository(context);

        private IProductRepository? product;
        public IProductRepository Product => product ??= new ProductRepository(context);

        private ICartRepository? cart;
        public ICartRepository Cart => cart ??= new CartRepository(context);

        private IOrderRepository? order;
        public IOrderRepository Order => order ??= new OrderRepository(context);

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
