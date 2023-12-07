using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANK14.BurgerShop.MVC.Controllers
{
    [Authorize(Roles = "AppAdmin")]
    public class MenuSizeController : Controller
    {
        private readonly IMenuSizeService _manager;
        private readonly IMapper _mapper;
        public MenuSizeController(IMenuSizeService manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var menuSizeDtos = await _manager.GetAllAsync(true);
            var menuSizeViewModels = _mapper.Map<List<MenuSizeViewModel>>(menuSizeDtos.Context);
            ViewBag.MenuSizes = menuSizeViewModels;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuSizeViewModel vm)
        {
            var dto = _mapper.Map<MenuSizeDto>(vm);
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
        public async Task<IActionResult> Update(MenuSizeViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<MenuSizeDto>(vm);
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

        public async Task<IActionResult> GetMenuSize(int id)
        {
            var dto = await _manager.GetAsync(true, x => x.Id == id);
            var vm = _mapper.Map<MenuSizeViewModel>(dto.Context);

            return PartialView("_MenuSizePartialView", vm);
        }
    }
}
