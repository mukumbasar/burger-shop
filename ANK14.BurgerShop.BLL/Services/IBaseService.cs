using ANK14.BurgerShop.BLL.ResponsePattern;
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
        Response InsertAsync(TDto dto);
        Response UpdateAsync(TDto dto);
        Response DeleteAsync(TDto dto);
        Response<TDto> GetAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
        Response<IEnumerable<TDto>> GetAllAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
