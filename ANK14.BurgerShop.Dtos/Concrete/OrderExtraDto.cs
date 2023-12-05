using ANK14.BurgerShop.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Dtos.Concrete
{
	public class OrderExtraDto : IDto
    {
		public int Id { get; set; }
		public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ExtraId { get; set; }
    }
}
