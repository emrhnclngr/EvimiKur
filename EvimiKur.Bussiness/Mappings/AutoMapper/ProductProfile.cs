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
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
