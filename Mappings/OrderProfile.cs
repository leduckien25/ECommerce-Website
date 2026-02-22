using AutoMapper;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CheckoutViewModel, Order>()
                        .ForMember(d => d.FullName,
                            opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                        .ForMember(d => d.OrderId, opt => opt.Ignore())
                        .ForMember(d => d.TotalAmount, opt => opt.Ignore())
                        .ForMember(d => d.OrderDate, opt => opt.Ignore())
                        .ForMember(d => d.UserId, opt => opt.Ignore())
                        .ForMember(d => d.Status, opt => opt.Ignore())
                        .ForMember(d => d.OrderDetails, opt => opt.Ignore());
        }
    }
}
