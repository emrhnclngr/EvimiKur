using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.Bussiness.ValidationRules.AppUserValidation;
using EvimiKur.Bussiness.ValidationRules.CategoryValidation;
using EvimiKur.Bussiness.ValidationRules.DealerValidation;
using EvimiKur.Bussiness.ValidationRules.ProductValidation;
using EvimiKur.DataAccess.Context;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EvimiKurContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });


            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();
            services.AddTransient<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();
            services.AddTransient<IValidator<DealerCreateDto>, DealerCreateDtoValidator>();
            services.AddTransient<IValidator<DealerUpdateDto>, DealerUpdateDtoValidator>();



            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDealerService, DealerService>();
            services.AddScoped<ICartService, CartService>();
            






        }
    }
}
