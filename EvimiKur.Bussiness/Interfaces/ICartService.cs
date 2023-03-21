﻿using EvimiKur.Common;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface ICartService
    {
        void AddToCart(ProductListDto product);
        void RemoveCart(ProductListDto product);
        List<ProductListDto> ProductInTheCart();
    }
}
