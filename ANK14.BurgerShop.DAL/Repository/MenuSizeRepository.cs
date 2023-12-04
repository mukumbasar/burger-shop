using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.DAL.Contexts;
using ANK14.BurgerShop.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.DAL.Repository
{
    public class MenuSizeRepository : GenericRepository<MenuSize>, IMenuSizeRepository
    {
        public MenuSizeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
