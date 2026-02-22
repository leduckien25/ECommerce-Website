using AutoMapper;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services.Interfaces;
using WebApplicationMvc.UnitOfWork;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Category? Create(Category category)
        {
            _uow.Category.Add(category);
            int result = _uow.SaveChanges();
            return result > 0 ? category : null;
        }

        public bool Delete(short id)
        {
            _uow.Category.Delete(id);
            return _uow.SaveChanges() > 0;
        }

        public IEnumerable<CategoryViewModel> GetCategoriesForDisplay()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(_uow.Category.GetCategoriesWithProducts());
        }

        public int GetCategoriesCount()
        {
            return _uow.Category.GetCategoriesCount();
        }

        public Category GetCategoryWithProducts(short id)
        {
            return _uow.Category.GetCategoryWithProducts(id);
        }

        public bool Update(Category category)
        {
            _uow.Category.Update(category);
            return _uow.SaveChanges() > 0;
        }

        public IEnumerable<Category> GetCategoriesForAdmin(int page, int pageSize)
        {
            return _uow.Category.GetCategories(page, pageSize);
        }

        public int GetTotalPages(int pageSize)
        {
            return (GetCategoriesCount() - 1) / pageSize + 1;
        }
    }
}
