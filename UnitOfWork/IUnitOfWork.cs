using WebApplicationMvc.Repositories.Interfaces;

namespace WebApplicationMvc.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public ICartRepository Cart { get; }
        public ICategoryRepository Category { get; }
        public IOrderRepository Order { get; }
        public ISupplierRepository Supplier { get; }
        public IProductRepository Product { get; }
        public int SaveChanges();
    }
}
