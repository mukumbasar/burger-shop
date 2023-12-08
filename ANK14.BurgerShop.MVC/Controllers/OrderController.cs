using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.Entities.Concretes;
using ANK14.BurgerShop.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static NuGet.Packaging.PackagingConstants;

namespace ANK14.BurgerShop.MVC.Controllers
{

    public class OrderController : Controller
    {
        private readonly IOrderService _orderManager;
        private readonly IExtraService _extraManager;
        private readonly IMenuService _menuManager;
        private readonly IMenuSizeService _menuSizeManager;
        private readonly IOrderExtraService _orderExtraManager;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderManager, IMenuService menuManager, IExtraService extraManager, IMenuSizeService menuSizeManager, IOrderExtraService orderExtraManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _menuManager = menuManager;
            _extraManager = extraManager;
            _menuSizeManager = menuSizeManager;
            _orderExtraManager = orderExtraManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var menuDtos = await _menuManager.GetAllAsync(true);
            var menuViewModels = _mapper.Map<List<MenuViewModel>>(menuDtos.Context);

            return View(menuViewModels);
        }

        public async Task<IActionResult> Place(int id)
        {
            var Menu = await _menuManager.GetAsync(true, x => x.Id == id);
            var Extras = await _extraManager.GetAllAsync(true);
            var MenuSizes = await _menuSizeManager.GetAllAsync(true);

            List<SelectListItem> menuSizesList = new List<SelectListItem>();

            foreach (var item in MenuSizes.Context)
            {
                menuSizesList.Add(new SelectListItem(item.Name + " " + item.AdditionalPrice.ToString() + " ₺", item.Id.ToString()));
            };

            var selectList = new SelectList(menuSizesList);

            ViewBag.Extras = Extras.Context;
            ViewBag.Menu = Menu.Context;
            ViewBag.MenuSizes = selectList.Items; 

            return View("Place");
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderViewModel vm)
        {
            var dto = _mapper.Map<OrderDto>(vm);

            if (ModelState.IsValid)
            {
                await _orderManager.InsertWithExtras(dto);

                return RedirectToAction("List");
            }

            return RedirectToAction("Place", new { id = dto.MenuId });
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var orders = (await _orderManager.ListOrders(User.FindFirst(ClaimTypes.NameIdentifier).Value)).Context;
            var Menus = (await _menuManager.GetAllAsync(true)).Context;
            var Extras = (await _extraManager.GetAllAsync(true)).Context;
            var MenuSizes = (await _menuSizeManager.GetAllAsync(true)).Context;

            #region Initialize SelectedItem Lists
            List<SelectListItem> menuSizesList = new List<SelectListItem>();

            foreach (var item in MenuSizes)
            {
                menuSizesList.Add(new SelectListItem(item.Name + " " + item.AdditionalPrice.ToString(), item.Id.ToString()));
            };

            List<SelectListItem> menusList = new List<SelectListItem>();

            foreach (var item in Menus)
            {
                menusList.Add(new SelectListItem(item.Name + " " + item.Price.ToString(), item.Id.ToString()));
            }; 
            #endregion

            ViewBag.Menus = menusList;
            ViewBag.MenuSizes = menuSizesList;
            ViewBag.Extras = Extras;
            ViewBag.Orders = orders;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var orderDto = _mapper.Map<OrderDto>(vm);

                await _orderManager.UpdateWithExtras(orderDto);

                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _orderManager.GetAsync(true, x => x.Id == id);

            await _orderManager.DeleteAsync(dto.Context);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> GetOrder(int id)
        {
            var orders = (await _orderManager.ListOrders(User.FindFirst(ClaimTypes.NameIdentifier).Value)).Context;
            var menus = (await _menuManager.GetAllAsync(true)).Context;
            var extras = (await _extraManager.GetAllAsync(true)).Context;
            var menuSizes = (await _menuSizeManager.GetAllAsync(true)).Context;

            #region Initialize SelectItem Lists
            List<SelectListItem> menuSizesList = new List<SelectListItem>();
            foreach (var item in menuSizes)
            {
                menuSizesList.Add(new SelectListItem(item.Name + " " + item.AdditionalPrice.ToString() + " ₺", item.Id.ToString()));
            };

            List<SelectListItem> menusList = new List<SelectListItem>();
            foreach (var item in menus)
            {
                menusList.Add(new SelectListItem(item.Name + " " + item.Price.ToString() + " ₺", item.Id.ToString()));
            }; 
            #endregion

            ViewBag.Menus = menusList;
            ViewBag.MenuSizes = menuSizesList;
            ViewBag.Extras = extras;
            ViewBag.Orders = orders;

            var dto = await _orderManager.GetAsync(true, x => x.Id == id);
            var vm = _mapper.Map<OrderViewModel>(dto.Context);
            
            return PartialView("_OrderPartialView", vm);
        }
    }
}



 

