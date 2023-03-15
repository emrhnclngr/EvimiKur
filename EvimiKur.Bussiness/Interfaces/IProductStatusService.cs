using EvimiKur.Dtos.ProductStatusDto;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface IProductStatusService : IService<ProductStatusCreateDto,ProductStatusUpdateDto, ProductStatusListDto, ProductStatus>
    {

    }
}
