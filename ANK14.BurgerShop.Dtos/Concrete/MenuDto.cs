using ANK14.BurgerShop.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Dtos.Concrete
{
	public class MenuDto : IDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string PhotoPath { get; set; }
	}
}
