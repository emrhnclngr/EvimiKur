using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Services
{
    public class OrderService : Service<OrderCreateDto,OrderUpdateDto,OrderListDto,Order>, IOrderService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IValidator<OrderCreateDto> createDtoValidator, IValidator<OrderUpdateDto> updateDtoValidator, IUow uow): base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
    }
}
