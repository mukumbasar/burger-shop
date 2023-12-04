using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.DAL.Contexts;
using ANK14.BurgerShop.DAL.Repository;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.DAL.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AppDbContext _context;
        private readonly IExtraRepository _extraRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IMenuSizeRepository _menuSizeRepository;
        private readonly IOrderExtraRepository _orderExtraRepository;
        private readonly IOrderRepository _orderRepository;

        public Uow(AppDbContext context, 
            IExtraRepository extraRepository,
            IMenuRepository menuRepository,
            IMenuSizeRepository menuSizeRepository,
            IOrderExtraRepository orderExtraRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            _extraRepository = extraRepository;
            _menuRepository = menuRepository;
            _menuSizeRepository = menuSizeRepository;
            _orderExtraRepository = orderExtraRepository;
            _orderRepository = orderRepository;
        }

        public IExtraRepository GetExtraRepository()
        {
            return _extraRepository;
        }

        public IMenuRepository GetMenuRepository()
        {
            return _menuRepository;
        }

        public IMenuSizeRepository GetMenuSizeRepository()
        {
            return _menuSizeRepository;
        }

        public IOrderExtraRepository GetOrderExtraRepository()
        {
            return _orderExtraRepository;
        }

        public IOrderRepository GetOrderRepository()
        {
            return _orderRepository;
        }

        IRepository<T> IUow.GetGenericRepository<T>()
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}
