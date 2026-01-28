using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplicationMvc.Data;
using WebApplicationMvc.Repositories;
using WebApplicationMvc.UnitOfWork;

namespace WebApplicationMvc.Providers
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EcommerceDbContext context;

        public UnitOfWork(EcommerceDbContext context)
        {
            this.context = context;
        }

        private CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                return category ??= new CategoryRepository(context);
            }
        }
        SupplierRepository supplier;
        public SupplierRepository Supplier
        {
            get
            {
                return supplier ??= new SupplierRepository(context);
            }
        }
        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                return product ??= new ProductRepository(context);
            }
        }
        CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                return cart ??= new CartRepository(context);
            }
        }
        OrderRepository order;
        public OrderRepository Order
        {
            get
            {
                return order ??= new OrderRepository(context);
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
