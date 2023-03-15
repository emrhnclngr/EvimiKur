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
    public interface ICategoryService : IService<CategoryCreateDto, CategoryUpdateDto, CategoryListDto,Category>
    {
        Task<List<CategoryListDto>> GetListActiveCategory();
        Task<List<CategoryListDto>> GetListInActiveCategory();
    }
}
