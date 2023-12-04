using ANK14.BurgerShop.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.DAL.Abstracts
{
	public interface IUow
	{
        void SaveChanges();
        IRepository<T> GetGenericRepository<T>() where T : class, IEntity;
    }
}
