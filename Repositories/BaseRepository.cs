using WebApplicationMvc.Data;

namespace WebApplicationMvc.Repositories
{
    public abstract class BaseRepository
    {
        protected EcommerceDbContext context;

        protected BaseRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
    }
}
