﻿using ANK14.BurgerShop.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.Dtos.Concrete
{
	public class LoginUserDto : IDto
    {
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
