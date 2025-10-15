using WebApplicationMvc.Data;

namespace WebApplicationMvc.Providers
{
    public abstract class BaseProvider
    {
        private readonly IServiceProvider _services;
        private EcommerceDbContext _context;

        public BaseProvider(IServiceProvider services)
        {
            _services = services;
        }

        protected EcommerceDbContext Context
        {
            get
            {
                return _context ??= _services.GetRequiredService<EcommerceDbContext>();
            }
        }
    }
}
