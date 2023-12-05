using ANK14.BurgerShop.BLL.ResponsePattern;
using ANK14.BurgerShop.BLL.Services;
using ANK14.BurgerShop.DAL.Abstracts;
using ANK14.BurgerShop.Dtos.Base;
using ANK14.BurgerShop.Entities.Abstracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Managers
{
    public class BaseManager<T, TDto> : IBaseService<T, TDto> where T : class, IEntity where TDto : class, IDto
    {
        protected readonly IMapper _mapper;
        protected readonly IUow _uow;

        public BaseManager(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response> InsertAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                await _uow.GetGenericRepository<T>().AddAsync(entity);
                _uow.SaveChanges();
                return Response.Success("Insertion was successful.");
            }
            catch
            {
                return Response.Failure("Insertion was unsuccessful");
            }
        }

        public async Task<Response> UpdateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                await _uow.GetGenericRepository<T>().UpdateAsync(entity);
                _uow.SaveChanges();
                return Response.Success("Updating was successful.");
            }
            catch
            {
                return Response.Failure("Updating was unsuccessful");
            }
        }

        public async Task<Response> DeleteAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                await _uow.GetGenericRepository<T>().DeleteAsync(entity);
                _uow.SaveChanges();
                return Response.Success("Deletion was successful.");
            }
            catch
            {
                return Response.Failure("Deletion was unsuccessful");
            }
        }

        public async Task<Response<TDto>> GetAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                var entity = await _uow.GetGenericRepository<T>().GetAsync(asNoTracking, filter, includeProperties);
                var dto = _mapper.Map<TDto>(entity);
                return Response<TDto>.Success(dto, "Acquirement was successful.");
            }
            catch
            {
                return Response<TDto>.Failure("Acquirement was unsuccessful");
            }
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                var entities = await _uow.GetGenericRepository<T>().GetAllAsync(asNoTracking, filter, includeProperties);
                var dtos = _mapper.Map<List<TDto>>(entities);
                return Response<IEnumerable<TDto>>.Success(dtos, "Acquirement was successful.");
            }
            catch
            {
                return Response<IEnumerable<TDto>>.Failure("Acquirement was unsuccessful");
            }
        }
    }
}
