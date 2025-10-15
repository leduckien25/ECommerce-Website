using WebApplicationMvc.Repositories;

namespace WebApplicationMvc.Providers
{
    public class SiteProvider : BaseProvider
    {
        public SiteProvider(IServiceProvider services) : base(services)
        {
        }
        CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                return category ??= new CategoryRepository(Context);
            }
        }
        SupplierRepository supplier;
        public SupplierRepository Supplier
        {
            get
            {
                return supplier ??= new SupplierRepository(Context);
            }
        }
        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                return product ??= new ProductRepository(Context);
            }
        }
        CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                return cart ??= new CartRepository(Context);
            }
        }
        OrderRepository order;
        public OrderRepository Order
        {
            get
            {
                return order ??= new OrderRepository(Context);
            }
        }


    }
}
