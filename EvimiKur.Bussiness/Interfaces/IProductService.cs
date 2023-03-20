using EvimiKur.Common;
using EvimiKur.Common.Enums;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface IProductService : IService<ProductCreateDto,ProductUpdateDto,ProductListDto,Product>
    {
        Task<IResponse<List<ProductListDto>>> GetActivesAsync();
        //Task<IResponse<List<ProductListDto>>> GetCategoryWithProduct();
        Task<List<ProductListDto>> GetList();
        Task<List<ProductListDto>> GetListActiveProduct();
        Task<List<ProductListDto>> GetListInActiveProduct();


    }
}
