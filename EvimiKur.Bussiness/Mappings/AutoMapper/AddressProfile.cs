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
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressListDto>().ReverseMap();
            CreateMap<Address, AddressUpdateDto>().ReverseMap();
        }
    }
}
