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
    public class ExtraSeedData : IEntityTypeConfiguration<Extra>
    {
        public void Configure(EntityTypeBuilder<Extra> builder)
        {
            builder.HasData(
                new Extra
                {
                    Id = 1,
                    Name = "Mini Hamburger",
                    AdditionalPrice = 25
                });
            builder.HasData(
                new Extra
                {
                    Id = 2,
                    Name = "Chicken Bites with Cheese x 4",
                    AdditionalPrice = 35
                });
            builder.HasData(
                new Extra
                {
                    Id = 3,
                    Name = "Vanilla Ice Cream Cone",
                    AdditionalPrice = 20
                });
        }
    }
}
