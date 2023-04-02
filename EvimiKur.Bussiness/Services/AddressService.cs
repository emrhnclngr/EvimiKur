using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common.Enums;
using EvimiKur.DataAccess.UnitOfWork;
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
    public class AddressService : Service<AddressCreateDto,AddressUpdateDto,AddressListDto,Address>,IAddressService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public AddressService(IMapper mapper,IValidator<AddressCreateDto> createDtoValidator, IValidator<AddressUpdateDto> updateDtoValidator, IUow uow): base(mapper, createDtoValidator, updateDtoValidator,uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<AddressListDto>> GetList(int id)
        {
            var query = _uow.GetRepository<Address>().GetQuery();

            var list = await query.Where(x => x.AppUserId == id).ToListAsync();

            return _mapper.Map<List<AddressListDto>>(list);
        }

    }
}
