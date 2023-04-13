using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetECommerce.Entity.Base;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetEcommerce.DAL.Context
{
    public class ProjectContext : IdentityDbContext<AppUser, AppUserRole, int>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }


        public override int SaveChanges()
        {
            var modifierEntiries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

            try
            {
                foreach (var item in modifierEntiries)
                {
                    var entityRepository = item.Entity as BaseEntity;
                    if (item.State == EntityState.Added)
                    {
                        entityRepository.CreatedComputerName = "";
                        entityRepository.CreatedIpAddress = "";
                        
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entityRepository.UpdatedIpAddress = "";
                        entityRepository.UpdatedComputerName = "";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return base.SaveChanges();
        }

        //FakeData
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }

    }
}
