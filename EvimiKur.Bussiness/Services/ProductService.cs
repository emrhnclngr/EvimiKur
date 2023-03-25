using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.Common.Enums;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var data = await _uow.GetRepository<Product>().GetAllAsync(x => x.Status, x => x.CreatedDate, OrderByType.DESC);
            var dto = _mapper.Map<List<ProductListDto>>(data);
            return new Response<List<ProductListDto>>(ResponseType.Success, dto);
        }


        public async Task<List<ProductListDto>> GetList()
        {
            var query = _uow.GetRepository<Product>().GetQuery();

            var list = await query.Include(x => x.Category).ToListAsync();

            return _mapper.Map<List<ProductListDto>>(list);
        }

        // Aşağıdaki metotlar if else yapısıyla birleştirilecek...
        public async Task<List<ProductListDto>> GetListActiveProduct()
        {
            var query = _uow.GetRepository<Product>().GetQuery();

            var list = await query.Include(x => x.Category).Include(x => x.Dealer).Where(x => x.Status == true).ToListAsync();

            return _mapper.Map<List<ProductListDto>>(list);
        }
        public async Task<List<ProductListDto>> GetListInActiveProduct()
        {
            var query = _uow.GetRepository<Product>().GetQuery();

            var list = await query.Include(x => x.Category).Include(x=>x.Dealer).Where(x => x.Status == false).ToListAsync();

            return _mapper.Map<List<ProductListDto>>(list);
        }
        





    }
}
