using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.Entities.Concretes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Managers
{
    public class MenuManager : BaseManager<Menu, MenuDto>, IMenuService
    {
        public MenuManager(IMapper mapper, IUow uow) : base(mapper, uow)
        {

        }
    }
}
