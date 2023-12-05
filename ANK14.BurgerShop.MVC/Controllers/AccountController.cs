using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ANK14.BurgerShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<RegisterUserDto>(vm);
                var result = await _accountService.RegisterAsync(dto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Login");
                }
                ViewBag.RegisterError = result.Message;
            }

            return View(vm);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel wm)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<LoginUserDto>(wm);
                var result = await _accountService.LoginAsync(dto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.LoginMessage = result.Message;
                return View(wm);
            }
            return View(wm);
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

