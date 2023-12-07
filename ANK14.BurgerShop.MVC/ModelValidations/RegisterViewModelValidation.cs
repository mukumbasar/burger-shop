using ANK14.BurgerShop.MVC.Models;
using FluentValidation;

namespace ANK14.BurgerShop.MVC.ModelValidations
{
    public class RegisterViewModelValidation : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidation()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı adı girmek zorunludur.");
            RuleFor(u => u.Name).NotEmpty().WithMessage("Ad girmek zorunludur.");
            RuleFor(u => u.Surname).NotEmpty().WithMessage("Soyad girmek zorunludur.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Mail girmek zorunludur.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola girmek zorunludur.");
            RuleFor(u => u.Address).NotEmpty().WithMessage("Adres girmek zorunludur.");
        }
    }
}
