using ANK14.BurgerShop.MVC.Models;
using FluentValidation;

namespace ANK14.BurgerShop.MVC.ModelValidations
{
    public class LoginViewModelValidation : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidation()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email adresi girmek zorunludur.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola girmek zorunludur.");
        }
    }
}
