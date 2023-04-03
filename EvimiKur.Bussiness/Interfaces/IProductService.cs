﻿using EvimiKur.Common;
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
        Task<List<ProductListDto>> GetList();
        Task<List<ProductListDto>> GetList(StatusType type);
        Task<List<ProductListDto>> Search(string query);
        Task<List<ProductListDto>> GetListShowroom();
        Task<List<ProductListDto>> GetProductByCategories(int categoryId, StatusType type);
    }
}
