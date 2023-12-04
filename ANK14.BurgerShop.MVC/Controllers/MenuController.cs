using ANK14.BurgerShop.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ANK14.BurgerShop.MVC.Controllers
{
    public class MenuController : Controller
    {

        //private readonly IMenuService _manager;
        //private readonly IMapper _mapper;
        //public MenuController(IMenuService manager, IMapper mapper )
        //{
        //    _manager = manager;
        //    _mapper = mapper;
        //}
        public async Task<IActionResult> List()
        {
            //var menus = await _manager.GetAll();
            //return View(menus);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddMenuViewModel vm)
        {
            //var dto = _mapper.Map<AddMenuDto>(vm);
            //if (ModelState.IsValid)
            //{
            //    await _manager.Add(dto);
            //    return RedirectToAction("List");
            //}
            //ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMenuViewModel vm)
        {
            //var dto = _mapper.Map<UpdateMenuDto>(vm);
            //if (ModelState.IsValid)
            //{
            //    await _manager.Update(dto);
            //    return RedirectToAction("List");
            //}
            //ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var dto = await _manager.Get(id);
            //await _manager.Delete(dto);
            //return RedirectToAction("List");
            return View();
        }

    }
}
