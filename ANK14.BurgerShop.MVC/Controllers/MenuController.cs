using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.MVC.Helpers;
using ANK14.BurgerShop.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANK14.BurgerShop.MVC.Controllers
{
    [Authorize(Roles = "AppAdmin")]
    public class MenuController : Controller
    {

        private readonly IMenuService _manager;
        private readonly IMapper _mapper;
        public MenuController(IMenuService manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var menuDtos = await _manager.GetAllAsync(true);
            var menuViewModels = _mapper.Map<List<MenuViewModel>>(menuDtos.Context);
            ViewBag.Menus = menuViewModels;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuViewModel vm)
        {

            var path = await ImageHelper.Insert(vm.Photo);

            vm.PhotoPath = path;

            var dto = _mapper.Map<MenuDto>(vm);
            if (ModelState.IsValid)
            {
                var result = await _manager.InsertAsync(dto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Error = result.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(MenuViewModel vm)
        {
            var path = await ImageHelper.Insert(vm.Photo);

            vm.PhotoPath = path;

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<MenuDto>(vm);
                var result = await _manager.UpdateAsync(dto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Error = result.Message;
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _manager.GetAsync(true, x => x.Id == id);

            await _manager.DeleteAsync(dto.Context);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetMenu(int id)
        {
            var dto = await _manager.GetAsync(true, x => x.Id == id);
            var vm = _mapper.Map<MenuViewModel>(dto.Context);

            return PartialView("_MenuPartialView", vm);
        }

    }
}
