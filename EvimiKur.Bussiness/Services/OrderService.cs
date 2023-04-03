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

            var list = await query.Include(x => x.AppUser).ThenInclude(x=>x.Addresses).Include(x => x.OrderDetails).Where(x=>x.Status == (int)type).ToListAsync();

            return _mapper.Map<List<OrderListDto>>(list);
        }
        public async Task<List<OrderListDto>> GetListAsync(int userId,StatusType type)
        {
            var query = _uow.GetRepository<Order>().GetQuery();
            var list = await query.Include(x=>x.AppUser).ThenInclude(x=>x.Addresses).Include(x => x.OrderDetails).ThenInclude(x=>x.Product).Where(x=>x.Status == (int)type && x.AppUserId == userId).ToListAsync();
            return _mapper.Map<List<OrderListDto>>(list);
        }
        public async Task SetStatusAsync(int orderId, StatusType type)
        {
            var query = _uow.GetRepository<Order>().GetQuery();

            var entity = await query.SingleOrDefaultAsync(x => x.Id == orderId);
            entity.Status = (int)type;
            await _uow.SaveChangesAsync();
        }


    }
}
