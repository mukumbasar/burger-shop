using ANK14.BurgerShop.BLL.ResponsePattern;
using ANK14.BurgerShop.Dtos.Base;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Services
{
    public interface IOrderService : IBaseService<Order, OrderDto>
    {
        Task<Response<IEnumerable<OrderDto>>> ListOrders(string Id);
        Task InsertWithExtras(OrderDto orderDto);
        Task UpdateWithExtras(OrderDto orderDto);
    } 
}
