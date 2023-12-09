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
        private IMenuService _menuManager;
        private UserManager<AppUser> _userManager;

        public OrderManager(IMapper mapper, IUow uow, IOrderExtraService orderExtraManager, 
                            IMenuService menuManager, UserManager<AppUser> userManager) : base(mapper, uow)
        {
            _orderExtraManager = orderExtraManager;
            _userManager = userManager;
            _menuManager = menuManager;
        }

        public async Task<Response<IEnumerable<OrderDto>>> ListOrders(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var orders = (await GetAllAsync(true, null, x => x.Menu, x=> x.MenuSize, x => x.AppUser)).Context;

            if (!await _userManager.IsInRoleAsync(user,"AppAdmin"))
            {
                orders = orders.Where(x => x.AppUserId == user.Id);
            }

            foreach (var order in orders)
            {
                var orderExtras = await _orderExtraManager.GetAllAsync(true, x => x.OrderId == order.Id, x => x.Extra);

                foreach (var orderExtra in orderExtras.Context)
                {
                    order.TotalPrice += orderExtra.Extra.AdditionalPrice;
                }

                order.AppUserNameAndSurname = order.AppUser.Name + " " + order.AppUser.Surname;

                order.TotalPrice += order.MenuSize.AdditionalPrice;
                order.TotalPrice += order.Menu.Price * order.Quantity;
            }

            return Response<IEnumerable<OrderDto>>.Success(orders, "Acquirement was successful.");
        }

        public async Task InsertWithExtras(OrderDto orderDto)
        {
            orderDto.OrderDate = DateTime.Now;

            var result = await InsertAsync(orderDto);

            var orders = (await GetAllAsync(true)).Context;

            var orderID = orders.OrderByDescending(x => x.Id).Select(x=>x.Id).First();

            foreach (var item in orderDto.SelectedExtraIds)
            {

                OrderExtraDto orderExtraDto = new()
                {
                    ExtraId = item,
                    OrderId = orderID
                };

                await _orderExtraManager.InsertAsync(orderExtraDto);
            }
        }

        public async Task UpdateWithExtras(OrderDto orderDto)
        {
            orderDto.OrderDate = DateTime.Now;

            var result = await UpdateAsync(orderDto);

            var orders = (await GetAllAsync(true)).Context;

            var orderExtras = (await _orderExtraManager.GetAllAsync(true, x=> x.OrderId == orderDto.Id)).Context;

            foreach (var extra in orderExtras)
            {
                await _orderExtraManager.DeleteAsync(extra);
            }

            foreach (var item in orderDto.SelectedExtraIds)
            {

                OrderExtraDto orderExtraDto = new()
                {
                    ExtraId = item,
                    OrderId = orderDto.Id
                };

                await _orderExtraManager.InsertAsync(orderExtraDto);
            }
        }
    }
}
