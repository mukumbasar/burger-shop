using ANK14.BurgerShop.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Dtos.Concrete
{
	public class ExtraDto : IDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int AdditionalPrice { get; set; }
	}
}
