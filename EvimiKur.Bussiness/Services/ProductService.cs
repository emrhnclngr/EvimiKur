﻿using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.Common.Enums;
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
    public class ProductService: Service<ProductCreateDto,ProductUpdateDto,ProductListDto,Product>,IProductService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductCreateDto> _createDtoValidator;

        public ProductService(IUow uow, IMapper mapper, IValidator<ProductCreateDto> createDtoValidator, IValidator<ProductUpdateDto> updateDtoValidator) : base (mapper,createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<List<ProductListDto>>> GetActivesAsync()
        {
            var data = await _uow.GetRepository<Product>().GetAllAsync(x => x.Status, x => x.CreatedDate,OrderByType.DESC);
            var dto = _mapper.Map<List<ProductListDto>>(data);
            return new Response<List<ProductListDto>>(ResponseType.Success, dto);
        }

    }
}