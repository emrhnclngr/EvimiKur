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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderListDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
            
        }
    }
}
