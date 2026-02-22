using AutoMapper;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Mappings
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierViewModel>()
                .ForMember(
                    dest => dest.ProductCount,
                    opt => opt.MapFrom(src => src.Products.Count()));
        }
    }
}
