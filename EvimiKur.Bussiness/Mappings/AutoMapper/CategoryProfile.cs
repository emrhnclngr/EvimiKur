using AutoMapper;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Mappings.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        }
    }
}
