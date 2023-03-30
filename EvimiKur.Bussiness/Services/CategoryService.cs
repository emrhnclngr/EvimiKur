using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
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
    public class CategoryService : Service<CategoryCreateDto, CategoryUpdateDto, CategoryListDto, Category>, ICategoryService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IValidator<CategoryCreateDto> createDtoValidator, IValidator<CategoryUpdateDto> updateDtoValidator, IUow uow) : base (mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<CategoryListDto>> GetList(StatusType type)
        {
            var query = _uow.GetRepository<Category>().GetQuery();

            var list = await query.Where(x => x.Status == (int)type).ToListAsync();

            return _mapper.Map<List<CategoryListDto>>(list);
        }
        //public async Task<List<CategoryListDto>> GetListInActiveCategory()
        //{
        //    var query = _uow.GetRepository<Category>().GetQuery();

        //    var list = await query.Where(x => x.Status == false).ToListAsync();

        //    return _mapper.Map<List<CategoryListDto>>(list);
        //}





    }
}
