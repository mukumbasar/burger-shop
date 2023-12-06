using ANK14.BurgerShop.BLL.ResponsePattern;
using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.Dtos.Base;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.Entities.Concretes;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Managers
{
    public class OrderManager : BaseManager<Order, OrderDto>, IOrderService
    {
        private IOrderExtraService _orderExtraManager;
        private UserManager<AppUser> _userManager;

        public OrderManager(IMapper mapper, IUow uow, IOrderExtraService orderExtraManager, UserManager<AppUser> userManager) : base(mapper, uow)
        {
            _orderExtraManager = orderExtraManager;
            _userManager = userManager;
        }

        public async Task<Response<IEnumerable<OrderDto>>> ListOrders(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(!await _userManager.IsInRoleAsync(user,"AppAdmin"))
            {
                var orders = await GetAllAsync(true, x => x.AppUserId == id, x=> x.Menu);

                foreach (var order in orders.Context)
                {
                    var orderExtras = await _orderExtraManager.GetAllAsync(true, x => x.OrderId == order.Id, x=> x.Extra);

                    foreach (var orderExtra in orderExtras.Context)
                    {
                        order.TotalPrice += orderExtra.Extra.AdditionalPrice;
                    }

                    order.TotalPrice += order.Menu.Price * order.Quantity;
                }

                return Response<IEnumerable<OrderDto>>.Success(orders.Context, "Acquirement was successful.");
            }
            var allOrders = await GetAllAsync(true, null, x => x.Menu);

            foreach (var order in allOrders.Context)
            {
                var orderExtras = await _orderExtraManager.GetAllAsync(true, x => x.OrderId == order.Id, x => x.Extra);

                foreach (var orderExtra in orderExtras.Context)
                {
                    order.TotalPrice += orderExtra.Extra.AdditionalPrice;
                }

                order.TotalPrice += order.Menu.Price * order.Quantity;
            }

            return Response<IEnumerable<OrderDto>>.Success(allOrders.Context, "Acquirement was successful.");
        }
    }
}
