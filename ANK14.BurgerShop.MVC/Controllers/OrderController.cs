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
    [Authorize(Roles = "AppAdmin,AppClient")]
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
            var Menu = await _menuManager.GetAsync(true,x => x.Id == id);
            var Extras = await _extraManager.GetAllAsync(true);
            var MenuSizes = await _menuSizeManager.GetAllAsync(true);
            ViewBag.Extras = Extras.Context;
            ViewBag.Menu = Menu.Context;

            List<SelectListItem> menuSizesList = new List<SelectListItem>();

            foreach (var item in MenuSizes.Context)
            {
                menuSizesList.Add(new SelectListItem(item.Name + " " + item.AdditionalPrice.ToString(), item.Id.ToString()));
            };

            var selectList = new SelectList(menuSizesList);

            ViewBag.MenuSizes = selectList.Items;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderViewModel vm)
        {
            var dto = _mapper.Map<OrderDto>(vm);
            if (ModelState.IsValid)
            {
                dto.OrderDate = DateTime.Now;
                var result = await _orderManager.InsertAsync(dto);

                if (result.IsSuccess)
                {
                    var orders = (await _orderManager.GetAllAsync(true)).Context;
                    var orderID = orders.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                    
                    foreach (var item in vm.SelectedExtraIds)
                    {
                        
                        OrderExtraDto orderExtraDto = new()
                        {
                            ExtraId = item,
                            OrderId = orderID
                        };

                        await _orderExtraManager.InsertAsync(orderExtraDto);
                    }
                    return RedirectToAction("List");
                }

                ViewBag.Error = result.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var a = await _orderManager.ListOrders(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var Menus = await _menuManager.GetAllAsync(true);
            var Extras = await _extraManager.GetAllAsync(true);
            var MenuSizes = await _menuSizeManager.GetAllAsync(true);
            

            List<SelectListItem> menuSizesList = new List<SelectListItem>();

            foreach (var item in MenuSizes.Context)
            {
                menuSizesList.Add(new SelectListItem(item.Name + " " + item.AdditionalPrice.ToString(), item.Id.ToString()));
            };

            var selectList = new SelectList(menuSizesList);


            List<SelectListItem> menusList = new List<SelectListItem>();

            foreach (var item in Menus.Context)
            {
                menusList.Add(new SelectListItem(item.Name + " " + item.Price.ToString(), item.Id.ToString()));
            };

            var selectList2 = new SelectList(menusList);
            ViewBag.Menus = selectList2.Items;
            ViewBag.MenuSizes = selectList.Items;
            ViewBag.Extras = Extras.Context;
            ViewBag.Orders = a.Context;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderViewModel vm)
        {

            ModelState.Remove("SelectedExtraIds");
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<OrderDto>(vm);
                dto.OrderDate = DateTime.Now;

                var result = await _orderManager.UpdateAsync(dto);

                if (result.IsSuccess)
                {
                    var orderID = vm.Id;
                    foreach (var item in vm.SelectedExtraIds)
                    {
                        OrderExtraDto orderExtraDto = new()
                        {
                            ExtraId = item,
                            OrderId = orderID
                        };
                        await _orderExtraManager.UpdateAsync(orderExtraDto);
                    }
                    return RedirectToAction("List");
                }

                ViewBag.Error = result.Message;
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
            var a = await _orderManager.ListOrders(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var Menus = await _menuManager.GetAllAsync(true);
            var Extras = await _extraManager.GetAllAsync(true);
            var MenuSizes = await _menuSizeManager.GetAllAsync(true);

            List<SelectListItem> menuSizesList = new List<SelectListItem>();

            foreach (var item in MenuSizes.Context)
            {
                menuSizesList.Add(new SelectListItem(item.Name + " " + item.AdditionalPrice.ToString(), item.Id.ToString()));
            };

            var selectList = new SelectList(menuSizesList);


            List<SelectListItem> menusList = new List<SelectListItem>();

            foreach (var item in Menus.Context)
            {
                menusList.Add(new SelectListItem(item.Name + " " + item.Price.ToString(), item.Id.ToString()));
            };

            var selectList2 = new SelectList(menusList);
            ViewBag.Menus = selectList2.Items;
            ViewBag.MenuSizes = selectList.Items;
            ViewBag.Extras = Extras.Context;
            ViewBag.Orders = a.Context;
            var dto = await _orderManager.GetAsync(true, x => x.Id == id);
            var vm = _mapper.Map<OrderViewModel>(dto.Context);
            
            
            return PartialView("_OrderPartialView", vm);
        }

    }
}



 

