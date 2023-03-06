using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
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
    public class CategoryService : Service<CategoryCreateDto, CategoryUpdateDto, CategoryListDto, Category>, ICategoryService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IValidator<CategoryCreateDto> createDtoValidator, IValidator<CategoryUpdateDto> updateDtoValidator, IUow uow) : base (mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        



    }
}
