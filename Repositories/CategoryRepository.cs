using Microsoft.EntityFrameworkCore;
using System.Composition.Convention;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories
{
    public class CategoryRepository : BaseRepository
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
        public IEnumerable<CategoryViewModel> GetCategoryViewModels()
                => context.Categories
                .Include(c => c.Products)
                .Select(c => new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    ProductCount = c.Products.Count()
                }).ToList();

        public int Add(Category category)
        {
            context.Categories.Add(category);
            return context.SaveChanges();
        }
        public int Update(Category category)
        {
            context.Categories.Update(category);
            return context.SaveChanges();
        }
        public int Delete(short id)
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                return context.SaveChanges();
            }
            return -1;
        }

        public int GetCategoriesCount()
        {
            return context.Categories.Count();
        }
    }
}
