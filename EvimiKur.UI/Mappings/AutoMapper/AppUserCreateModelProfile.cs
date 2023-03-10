using AutoMapper;
using EvimiKur.Dtos;
using EvimiKur.UI.Models;

namespace EvimiKur.UI.Mappings.AutoMapper
{
    public class AppUserCreateModelProfile : Profile
    {
        public AppUserCreateModelProfile()
        {
            CreateMap<AppUserCreateModel, AppUserCreateDto>();
        }
    }
}
