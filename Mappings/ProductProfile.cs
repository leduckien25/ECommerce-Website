using AutoMapper;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.CategoryName)
                )
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.CategoryId)
                );
        }
    }
}
