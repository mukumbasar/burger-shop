using ANK14.BurgerShop.MVC.Models;
using FluentValidation;

namespace ANK14.BurgerShop.MVC.ModelValidations
{
    public class ExtraViewModelValidation : AbstractValidator<ExtraViewModel>
    {
        public ExtraViewModelValidation()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Ad girmek zorunludur.");
            RuleFor(u => u.AdditionalPrice).NotEmpty().WithMessage("Ek ücret girmek zorunludur.");
        }
    }
}
