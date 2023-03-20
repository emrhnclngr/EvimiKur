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
    public class DealerProfile : Profile
    {
        public DealerProfile()
        {
            CreateMap<Dealer, DealerCreateDto>().ReverseMap();
            CreateMap<Dealer, DealerListDto>().ReverseMap();
            CreateMap<Dealer, DealerUpdateDto>().ReverseMap();
        }
    }
}
