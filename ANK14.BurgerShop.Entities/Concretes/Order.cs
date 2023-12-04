using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Entities.Concretes
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }      

        List<OrderExtra> OrderExtras { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int MenuSizeId { get; set; }
        public MenuSize MenuSize { get; set; }
    }
}
