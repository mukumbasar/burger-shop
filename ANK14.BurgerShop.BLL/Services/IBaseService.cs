﻿using ANK14.BurgerShop.BLL.ResponsePattern;
using ANK14.BurgerShop.Dtos.Base;
using ANK14.BurgerShop.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Services
{
    public interface IBaseService<T, TDto> where T : class, IEntity where TDto : class, IDto
    {
        Task<Response> InsertAsync(TDto dto);
        Task<Response> UpdateAsync(TDto dto);
        Task<Response> DeleteAsync(TDto dto);
        Task<Response<TDto>> GetAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<Response<IEnumerable<TDto>>> GetAllAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
