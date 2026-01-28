using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetCategories(out int pages, int page, int size = 12);

        Category GetCategory(short id);
        Category GetCategoryWithProducts(short id);
        void Add(Category category);
        void Update(Category category);
        void Delete(short id);

        int GetCategoriesCount();
    }
}
