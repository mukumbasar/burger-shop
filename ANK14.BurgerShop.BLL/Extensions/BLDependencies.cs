using ANK14.BurgerShop.BLL.Managers;
using ANK14.BurgerShop.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Extensions
{
    public static class BLDependencies
    {
        public static void AddBlDependencies(this IServiceCollection services, Assembly configFromAssembly)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly(), configFromAssembly);

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IExtraService, ExtraManager>();
            services.AddScoped<IMenuService, MenuManager>();
            services.AddScoped<IMenuSizeService, MenuSizeManager>();
            services.AddScoped<IOrderExtraService, OrderExtraManager>();
            services.AddScoped<IOrderService, OrderManager>();
        }
    }
}
