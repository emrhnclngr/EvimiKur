using AutoMapper;
using EvimiKur.Dtos;
using EvimiKur.Dtos.ProductStatusDto;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Mappings.AutoMapper
{
    public class ProductStatusProfile : Profile
    {
        public ProductStatusProfile()
        {
            CreateMap<ProductStatus, ProductStatusListDto>().ReverseMap();
            CreateMap<ProductStatus, ProductStatusCreateDto>().ReverseMap();
            CreateMap<ProductStatus, ProductStatusUpdateDto>().ReverseMap();
        }
        
    }
}
