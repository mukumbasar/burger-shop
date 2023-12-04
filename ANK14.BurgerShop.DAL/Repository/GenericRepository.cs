using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.DAL.Contexts;
using ANK14.BurgerShop.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.DAL.Repository
{
	public class GenericRepository<T> :IRepository<T> where T : class,IEntity
	{
		private readonly AppDbContext _appDbContext;
		public GenericRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
	}
}
