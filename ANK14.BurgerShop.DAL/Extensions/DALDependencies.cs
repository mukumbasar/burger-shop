using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.DAL.Contexts;
using ANK14.BurgerShop.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANK14.BurgerShop.DAL.UnitOfWork;

namespace ANK14.BurgerShop.DAL.Extensions
{
    public static class DALDependencies
    {
        public static void AddDALDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });

            #region Identity Container Configuration
            services.AddIdentity<AppUser, AppRole>(option =>
            {
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = false;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                option.Lockout.MaxFailedAccessAttempts = 6;

                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;

            }).AddDefaultTokenProviders()
              .AddEntityFrameworkStores<AppDbContext>();
            #endregion

            #region Uow
            services.AddScoped<IUow, Uow>();
            #endregion
        }

    }
}

