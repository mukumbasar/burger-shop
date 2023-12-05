using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.Entities.Concretes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Mappings
{
    public class BLLModelProfile : Profile
    {
        public BLLModelProfile()
        {
            CreateMap<AppUser,RegisterUserDto>().ReverseMap();
            CreateMap<AppUser,LoginUserDto>().ReverseMap();
            CreateMap<Extra,ExtraDto>().ReverseMap();
            CreateMap<Menu,MenuDto>().ReverseMap();
            CreateMap<MenuSize,MenuSizeDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<OrderExtra, OrderExtraDto>().ReverseMap();
		}
	}
}
