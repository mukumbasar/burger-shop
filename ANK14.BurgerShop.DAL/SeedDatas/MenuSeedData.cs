using ANK14.BurgerShop.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.DAL.SeedDatas
{
    public class MenuSeedData : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(
                new Menu
                {
                    Id = 1,
                    Name = "Cheeseburger Menu",
                    Price = 160,
                    PhotoPath = "/images/cheeseburger.jpg"

                },
                new Menu
                {
                    Id = 2,
                    Name = "Roadhouse Menu",
                    Price = 175,
                    PhotoPath = "/images/roadhouse.jpg"
                },
                new Menu
                {
                    Id = 3,
                    Name = "Big Menu",
                    Price = 200,
                    PhotoPath = "/images/big.jpg"
                },
                new Menu
                {
                    Id = 4,
                    Name = "Hot Chickenburger Menu",
                    Price = 155,
                    PhotoPath = "/images/chickenburger.jpg"
                }

                );
            
        }
    }
}
