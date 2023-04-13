using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetEcommerce.DAL.Context;
using System.ComponentModel.Design;
using NetECommerce.IOC.Container;
using NetECommerce.IOC.Seed;
using NetECommerce.Entity.Entity;
using Microsoft.AspNetCore.Identity;
using System;

namespace NetECommerce.MVC
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
            services.AddControllersWithViews();
           

            //DbContext
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //Services

            ServiceIOC.ServiceConfigure(services);

            //Identity Service
            //token oluþturmak istediðimizde bu metodu dahil etmek zorundayýz!


            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Login");
                x.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    Name = "Login_cookie"
                };
                x.SlidingExpiration = true;
                x.ExpireTimeSpan=TimeSpan.FromMinutes(5);

            });

            services.AddSession(x =>
            {
                x.Cookie.Name = "product_cart_session";
                x.IdleTimeout = TimeSpan.FromMinutes(5);

            });

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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            SeedData.Seed(app);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //Dashboard Route

                endpoints.MapControllerRoute(
                     name: "areas",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                //confirmation route
                endpoints.MapControllerRoute(
                    name: "confirmation",
                    pattern: "{controller=Home}/{action=Confirmation}/{id}/{registerCode}"
                    );



                //Default Route

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
