using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface IDealerService : IService<DealerCreateDto,DealerUpdateDto,DealerListDto,Dealer>
    {
        Task<List<DealerListDto>> GetListActiveDealers();
        Task<List<DealerListDto>> GetList();
    }
}
