using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategoriesForAdmin(int page, int pageSize);
        IEnumerable<CategoryViewModel> GetCategoriesForDisplay();
        Category GetCategoryWithProducts(short id);
        int GetCategoriesCount();
        bool Update(Category category);
        bool Delete(short id);
        Category? Create(Category category);
        int GetTotalPages(int pageSize);
    }
}
