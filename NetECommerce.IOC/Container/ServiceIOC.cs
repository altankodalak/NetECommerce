using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetEcommerce.DAL.Context;
using NetECommerce.BLL.Abstract;
using NetECommerce.BLL.AbstractService;
using NetECommerce.BLL.Concrete;
using NetECommerce.BLL.Service;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace NetECommerce.IOC.Container
{
    public static class ServiceIOC
    {
        //ServiceConfigure
        public static void ServiceConfigure(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            //Identity
            services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<ProjectContext>().AddDefaultTokenProviders();

            //Jwt Service
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        //ValidateIssuer
                        ValidateIssuer = true,
                        //ValidateAudience
                        ValidateAudience = true,
                        //ValidateLifeTime
                        ValidateLifetime = true,
                        //ValidateIssuerSignInKey
                        ValidateIssuerSigningKey = true,
                        //ValidIssuer
                        ValidIssuer = "https://localhost:44345",
                        //ValidaAuidence
                        ValidAudience = "https://localhost:44345",
                        //IssuerSignInKey
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("b51487ad3be4760cada8cfb4523451c2459f8c398d98ee3657ca4729797195d7"))
                    };
                });

        }
    }
}
