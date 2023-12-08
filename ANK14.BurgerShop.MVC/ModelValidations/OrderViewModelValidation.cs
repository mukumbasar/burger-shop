using ANK14.BurgerShop.MVC.Models;
using FluentValidation;

namespace ANK14.BurgerShop.MVC.ModelValidations
{
    public class OrderViewModelValidation : AbstractValidator<OrderViewModel>
    {
        public OrderViewModelValidation()
        {
            RuleFor(u => u.Quantity).NotEmpty().WithMessage("Miktar girmek zorunludur.");
            RuleFor(u => u.Quantity).GreaterThan(0);
            RuleFor(u => u.MenuSizeId).NotEmpty().WithMessage("Menü boyutu girmek zorunludur.");
        }
    }
}
