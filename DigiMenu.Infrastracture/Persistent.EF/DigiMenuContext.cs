using DigiMenu.Domain.CategoryAgg;
using DigiMenu.Domain.PageSettingAgg;
using DigiMenu.Domain.ProductAgg;
using DigiMenu.Domain.RoleAgg;
using DigiMenu.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF
{
    public class DigiMenuContext : DbContext
    {
        public DigiMenuContext(DbContextOptions<DigiMenuContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<PageSetting> PageSettings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DigiMenuContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
