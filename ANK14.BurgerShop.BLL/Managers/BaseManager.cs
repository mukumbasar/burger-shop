using ANK14.BurgerShop.DAL.Abstracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.BurgerShop.BLL.Managers
{
    public class BaseManager<T,TDto> 
    {
        protected readonly IMapper _mapper;
        protected readonly IUow _uow;
        public BaseManager(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public Reponse Delete()
    }
}
