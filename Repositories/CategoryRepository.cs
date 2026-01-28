using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.Repositories.Interfaces;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(EcommerceDbContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetCategories() => context.Categories;

        public IEnumerable<Category> GetCategories(out int pages, int page, int size = 12)
        {
            pages = (context.Categories.Count() - 1) / size + 1;
            return context.Categories.Skip((page - 1) * size).Take(size);
        }
        public Category GetCategory(short id) => context.Categories.Find(id);
        public Category GetCategoryWithProducts(short id) => context.Categories.Where(c => c.CategoryId == id).Include(c => c.Products).ThenInclude(p => p.Supplier).SingleOrDefault();

        public void Add(Category category)
        {
            context.Categories.Add(category);
        }
        public void Update(Category category)
        {
            context.Categories.Update(category);
        }
        public void Delete(short id)
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                context.Categories.Remove(category);
            }
        }

        public int GetCategoriesCount()
        {
            return context.Categories.Count();
        }
    }
}
