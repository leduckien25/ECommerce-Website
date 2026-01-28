using AutoMapper;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(
                    dest => dest.ProductCount,
                    opt => opt.MapFrom(src => src.Products.Count()));
        }
    }
}
