using AutoMapper;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using EvimiKur.UI.Models;

namespace EvimiKur.UI.Mappings.AutoMapper
{
    public class ProductCreateModelProfile : Profile
    {
        public ProductCreateModelProfile()
        {
            CreateMap<ProductCreateModel, ProductCreateDto>().ReverseMap();
            CreateMap<ProductCreateModel,ProductListDto>().ReverseMap();
            CreateMap<Product, ProductCreateModel>().ReverseMap();
            CreateMap<Product, ProductListModel>().ReverseMap();
           

        }
    }
}
