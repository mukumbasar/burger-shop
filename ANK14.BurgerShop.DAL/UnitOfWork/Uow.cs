using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.DAL.Contexts;
using ANK14.BurgerShop.DAL.Repository;
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

        public Uow(AppDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        IRepository<T> IUow.GetGenericRepository<T>()
        {
            return new GenericRepository<T>(_context);
        }
    }
}
