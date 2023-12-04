using ANK14.BurgerShop.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Entities.Concretes
{
    public class Extra : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdditionalPrice { get; set; }
    }
}
