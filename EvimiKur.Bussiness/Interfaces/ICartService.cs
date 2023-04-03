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
    public interface ICartService
    {
        void Add(ProductListDto product);       
        List<ProductListDto> List();                         
        void Remove(int productId);       
        void IncreaseCartCookie(int id);
        void DecreaseCartCookie(int id);
    }
}
