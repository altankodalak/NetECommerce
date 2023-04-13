using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetEcommerce.DAL.Context;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetECommerce.Entity.Enum;

namespace NetECommerce.IOC.Seed
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {

            //Using blğunu middleware'de servis dışında kalmamak için kullanıyoruz. Middleware yapısı sadece singleton yapıları desteklemektedir. Servis yapısını seed classı içerisinde kullanmaj için  using bloğuna ihtiyacımız bulunmaktadır.
            using (var serviceScope=app.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<ProjectContext>();

                context.Database.Migrate();

                //Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { CategoryName = "Teknoloji", Description = "teknolojik ürünler", Status = Status.Inserted },
               new Category { CategoryName = "Giyim", Description = "yazlık kışlık giyim ürünleri", Status = Status.Inserted }
                        );

                    context.SaveChanges();
                }


                //Suppliers
                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(
                        new Supplier { 
                            CompanyName = "Kuzenler Tic.",
                            EmailAddress = "kuzen@abc.com" },
                         new Supplier
                         {
                             CompanyName = "Kardeşler Tic.",
                             EmailAddress = "kardes@abc.com"
                         }
                        );
                    context.SaveChanges();
                }

                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                    new Product {
                        ProductName = "MSI", 
                        UnitPrice = 20000, 
                        UnitsInStock = 50, 
                        CategoryId = 1,
                        SupplierId=1,
                        Status =Status.Inserted },
                     new Product {
                         ProductName = "Nike Ayakkabı", 
                         UnitPrice = 2000, 
                         UnitsInStock = 150, 
                         CategoryId = 2, 
                         SupplierId=2,
                         Status =Status.Inserted }
                        );
                    context.SaveChanges();
                }

                //Shipper

                if (!context.Shippers.Any())
                {
                    context.Shippers.AddRange(
                    new Shipper
                    {
                        CompanyName = "Tavuk Kargo",
                        Address = "İstanbul",
                    }
                    
                        );
                    context.SaveChanges();
                }


                

            }
        }
    }
}
