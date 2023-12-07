using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ANK14.BurgerShop.MVC.Controllers
{
    [Authorize(Roles = "AppAdmin")]
    public class ExtraController : Controller
    {
        private readonly IExtraService _manager;
        private readonly IMapper _mapper;
        public ExtraController(IExtraService manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var extraDtos = await _manager.GetAllAsync(true);
            var extraViewModels = _mapper.Map<List<ExtraViewModel>>(extraDtos.Context);
            ViewBag.Extras = extraViewModels;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExtraViewModel vm)
        {
            var dto = _mapper.Map<ExtraDto>(vm);
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
        public async Task<IActionResult> Update(ExtraViewModel vm)
        {
            
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ExtraDto>(vm);
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
            var dto = await _manager.GetAsync(true,x => x.Id == id);

            await _manager.DeleteAsync(dto.Context);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetExtra(int id)
        {
            var dto = await _manager.GetAsync(true, x => x.Id == id);
            var vm =_mapper.Map<ExtraViewModel>(dto.Context);


            return PartialView("_ExtraPartialView", vm);
        }
    }
}
