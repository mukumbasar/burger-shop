using ANK14.BurgerShop.MVC.Models;
using FluentValidation;

namespace ANK14.BurgerShop.MVC.ModelValidations
{
    public class MenuViewModelValidation : AbstractValidator<MenuViewModel>
    {
        public MenuViewModelValidation()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Ad girmek zorunludur.");
            RuleFor(u => u.Price).NotEmpty().WithMessage("Ücret girmek zorunludur.");
        }
    }
}
