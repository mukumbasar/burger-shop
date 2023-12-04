using ANK14.BurgerShop.Entities.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Entities.Concretes
{
    public class AppUser : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
