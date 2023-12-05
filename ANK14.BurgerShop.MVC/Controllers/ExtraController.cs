using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ANK14.BurgerShop.MVC.Controllers
{
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

            return View("Index");
        }
            
        [HttpPost]
        public async Task<IActionResult> Update(ExtraViewModel vm)
        {
            //var dto = _mapper.Map<UpdateExtraDto>(vm);
            //if (ModelState.IsValid)
            //{
            //    await _manager.Update(dto);
            //    return RedirectToAction("List");
            //}
            //ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _manager.GetAsync(true,x => x.Id == id);

            await _manager.DeleteAsync(dto.Context);
            return RedirectToAction("Index");
        }
    }
}
