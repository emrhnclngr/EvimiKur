using EvimiKur.Common;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface IProductService : IService<ProductCreateDto,ProductUpdateDto,ProductListDto,Product>
    {
        Task<IResponse<List<ProductListDto>>> GetActivesAsync();
    }
}
