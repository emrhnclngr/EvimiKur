using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface IAddressService : IService<AddressCreateDto,AddressUpdateDto,AddressListDto,Address> 
    {
        Task<List<AddressListDto>> GetList(int id);
    }
}
