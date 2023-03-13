using EvimiKur.Common;
using EvimiKur.Dtos.AppRoleDtos;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvimiKur.Common.Enums;

namespace EvimiKur.Bussiness.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
        Task<IResponse<List<AppUserLoginDto>>> GeyByLoginUserId(int id);
        //Task<List<AppUserListDto>> GetList(RoleType type);


    }
}
