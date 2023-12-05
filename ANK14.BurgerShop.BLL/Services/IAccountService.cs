using ANK14.BurgerShop.BLL.ResponsePattern;
using ANK14.BurgerShop.Dtos.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Services
{
    public interface IAccountService
    {
        Task<Response> RegisterAsync(RegisterUserDto registerUserDto);
        Task<Response> LoginAsync(LoginUserDto loginUserDto);
		Task LogoutAsync();
    }
}
