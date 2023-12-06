using ANK14.BurgerShop.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Entities.Concretes
{
    public class OrderExtra : IEntity
    {
        public int Id { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public Extra Extra { get; set; }
        public int ExtraId { get; set; }
    }
}
