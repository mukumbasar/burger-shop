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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
