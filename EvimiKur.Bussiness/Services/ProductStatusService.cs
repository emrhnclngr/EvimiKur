using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos.ProductStatusDto;
using EvimiKur.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Services
{
    public class ProductStatusService : Service<ProductStatusCreateDto,ProductStatusUpdateDto, ProductStatusListDto,ProductStatus>, IProductStatusService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public ProductStatusService(IMapper mapper, IValidator<ProductStatusCreateDto> createDtoValidator, IValidator<ProductStatusUpdateDto> updateDtoValidator, IUow uow) : base (mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
