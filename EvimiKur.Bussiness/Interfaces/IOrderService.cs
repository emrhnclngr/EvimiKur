using EvimiKur.Common.Enums;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface IOrderService : IService<OrderCreateDto, OrderUpdateDto,OrderListDto,Order>
    {
        Task<List<OrderListDto>> GetList(StatusType type);
        Task SetStatusAsync(int orderId, StatusType type);
        Task<List<OrderListDto>> GetListAsync(int userId, StatusType type);
    }
}
