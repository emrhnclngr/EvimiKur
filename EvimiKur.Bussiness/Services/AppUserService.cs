using AutoMapper;
using EvimiKur.Business.Extensions;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos.AppRoleDtos;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvimiKur.Dtos.Interfaces;
using System.Data;
using EvimiKur.Common.Enums;

namespace EvimiKur.Bussiness.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }
        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                //1.yol

                //user.AppUserRoles = new List<AppUserRole>();
                //user.AppUserRoles.Add(new AppUserRole
                //{
                //    AppUser = user,
                //    AppRoleId = roleId
                //});
                await _uow.GetRepository<AppUser>().CreateAsync(user);

                //2.yol
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);

                //await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                //{
                //    AppRoleId = roleId,
                //    AppUserId
                //});
            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
        }
        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı veya şifre hatalı");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz");
        }
        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "İlgili rol bulunamadı");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);

            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
        public async Task<IResponse<List<AppUserLoginDto>>> GeyByLoginUserId(int id)
        {
            var query = await _uow.GetRepository<AppUser>().FindAsync(id);

            var dto = _mapper.Map<List<AppUserLoginDto>>(query);

            return new Response<List<AppUserLoginDto>>(ResponseType.Success, dto);
        }
        //public async Task<List<AppUserListDto>> GetList(RoleType type)
        //{
        //    var query = _uow.GetRepository<AppUser>().GetQuery();

        //    var list = await query.Include(x => x.AppUserRoles).Where(x => x.Id == (int)type).ToListAsync(); ;

        //    return _mapper.Map<List<AppUserListDto>>(list);
        //}



    }
}
