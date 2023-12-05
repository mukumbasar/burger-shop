using ANK14.BurgerShop.BLL.ResponsePattern;
using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.Dtos.Base;
using ANK14.BurgerShop.Dtos.Concrete;
using ANK14.BurgerShop.Entities.Concretes;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Managers
{
	public class AccountManager : IAccountService
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public AccountManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_mapper = mapper;
		}
		public async Task<Response> LoginAsync(LoginUserDto loginUserDto)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(loginUserDto.Email);
				await _signInManager.SignOutAsync();
				var result= await _signInManager.PasswordSignInAsync(user,loginUserDto.Password,true,false);
				if(result.Succeeded)
				{
					await _userManager.ResetAccessFailedCountAsync(user);
					await _userManager.SetLockoutEndDateAsync(user, null);
					return Response.Success();
				}
				if(result.IsLockedOut)
				{
					var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
					var timeLeft=lockoutEndUtc.Value - DateTime.UtcNow;
					return Response.Failure($"Giriş başarısız. Lütfen {timeLeft} dakika sonra tekrar deneyiniz.");
				}
				return Response.Failure("Giriş Başarısız");
			}
			catch
			{
				return Response.Failure("Email ya da parola yanlış girildi.");
			}
		}

		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<Response> RegisterAsync(RegisterUserDto registerUserDto)
		{
			var user = _mapper.Map<AppUser>(registerUserDto);

			var result = await _userManager.CreateAsync(user, registerUserDto.Password);

			if (result.Succeeded)
			{
                await _userManager.AddToRoleAsync(user, "AppClient");
                return Response.Success();
			}
			var errorList = result.Errors.Select(x =>
			 x.Description
			 ).ToList();
			string errors = string.Empty;
			foreach (var error in errorList)
			{
				errors += error + "\n";
			}
			return Response.Failure(errors);
		}
	}
}
