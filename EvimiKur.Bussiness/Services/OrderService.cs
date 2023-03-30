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
    public class OrderService : Service<OrderCreateDto, OrderUpdateDto, OrderListDto, Order>, IOrderService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IValidator<OrderCreateDto> createDtoValidator, IValidator<OrderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<OrderListDto>> GetList(StatusType type)
        {
            var query = _uow.GetRepository<Order>().GetQuery();

            var list = await query.Include(x => x.AppUser).Where(x=>x.Status == (int)type).ToListAsync();

            return _mapper.Map<List<OrderListDto>>(list);
        }

    }
}
