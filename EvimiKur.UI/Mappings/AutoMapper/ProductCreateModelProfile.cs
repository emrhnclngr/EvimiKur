using AutoMapper;
using EvimiKur.Dtos;
using EvimiKur.UI.Models;

namespace EvimiKur.UI.Mappings.AutoMapper
{
    public class ProductCreateModelProfile : Profile
    {
        public ProductCreateModelProfile()
        {
            CreateMap<ProductCreateModel, ProductCreateDto>();
        }
    }
}
