using ANK14.BurgerShop.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.DAL.SeedDatas
{
    public class MenuSizeSeedData : IEntityTypeConfiguration<MenuSize>
    {
        public void Configure(EntityTypeBuilder<MenuSize> builder)
        {
            builder.HasData(
                new MenuSize
                {
                    Id = 1,
                    Name = "S",
                    AdditionalPrice = 30
                });
            builder.HasData(
                new MenuSize
                {
                    Id = 2,
                    Name = "M",
                    AdditionalPrice = 35
                });
            builder.HasData(
                new MenuSize
                {
                    Id = 3,
                    Name = "L",
                    AdditionalPrice = 40
                });
        }
    }
}
