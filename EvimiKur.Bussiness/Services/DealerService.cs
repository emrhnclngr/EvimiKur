using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Services
{
    public class DealerService : Service<DealerCreateDto,DealerUpdateDto,DealerListDto,Dealer>, IDealerService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<DealerCreateDto> _createDtoValidator;

        public DealerService(IUow uow, IMapper mapper, IValidator<DealerCreateDto> createDtoValidator, IValidator<DealerUpdateDto> updateDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }


        public async Task<List<DealerListDto>> GetListActiveDealers()
        {
            var query = _uow.GetRepository<Dealer>().GetQuery();

            var list = await query.Include(x => x.Products).ThenInclude(x=>x.Category).Where(x => x.Status == true).ToListAsync();

            return _mapper.Map<List<DealerListDto>>(list);
        }
        public async Task<List<DealerListDto>> GetList()
        {
            var query = _uow.GetRepository<Dealer>().GetQuery();

            var list = await query.Include(x => x.Products).ThenInclude(x => x.Category).ToListAsync();

            return _mapper.Map<List<DealerListDto>>(list);
        }



    }
}
