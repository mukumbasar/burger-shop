using ANK14.BurgerShop.Dtos.Base;
using ANK14.BurgerShop.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Dtos.Concrete
{
	public class OrderDto : IDto
    {
		public int Id { get; set; }
		public int Quantity { get; set; }
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? AppUserNameAndSurname { get; set; }
        public int MenuId { get; set; }
        public Menu? Menu { get; set; }
        public int MenuSizeId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<int>? SelectedExtraIds { get; set; }
    }
}
