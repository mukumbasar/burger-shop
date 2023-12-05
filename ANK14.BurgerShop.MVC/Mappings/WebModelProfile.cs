using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.Entities.Concretes;
using ANK14.BurgerShop.MVC.Models;
using AutoMapper;

namespace ANK14.BurgerShop.MVC.Mappings
{
    public class WebModelProfile : Profile
    {
        public WebModelProfile()
        {
            CreateMap<RegisterViewModel, RegisterUserDto>().ReverseMap();
            CreateMap<LoginViewModel, LoginUserDto>().ReverseMap();
            CreateMap<ExtraViewModel, ExtraDto>().ReverseMap();
            CreateMap<MenuViewModel, MenuDto>().ReverseMap();
            CreateMap<MenuSizeViewModel, MenuSizeDto>().ReverseMap();
            CreateMap<OrderViewModel, OrderDto>().ReverseMap();
            CreateMap<OrderExtraViewModel, OrderExtraDto>().ReverseMap();
        }
    }
}
