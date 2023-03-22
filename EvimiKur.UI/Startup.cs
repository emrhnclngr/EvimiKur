using AutoMapper;
using EvimiKur.Business.Helpers;
using EvimiKur.Bussiness.DependencyResolvers.Microsoft;
using EvimiKur.UI.Mappings.AutoMapper;
using EvimiKur.UI.Models;
using EvimiKur.UI.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvimiKur.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);

            services.AddTransient<IValidator<ProductCreateModel>, ProductCreateModelValidator>();
            services.AddTransient<IValidator<AppUserCreateModel>, AppUserCreateModelValidator>();
            


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(opt =>
   {
       opt.Cookie.Name = "EvimiKurCookie";
       opt.Cookie.HttpOnly = true;
       opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
       opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
       opt.ExpireTimeSpan = TimeSpan.FromDays(20);
       opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogIn");
       opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
       opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");

   });
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "sepet";
            //    options.Cookie.Expiration = TimeSpan.FromDays(30);
            //});
            // Sepet için yapmýþ olduðum cookie ait.


            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddSession();

            var profiles = ProfileHelper.GetProfiles();

            profiles.Add(new ProductCreateModelProfile());
            profiles.Add(new AppUserCreateModelProfile());
            
            

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{Controller=Home}/{Action=Index}/{id?}"
                    );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
