using DigiMenu.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.ProductAgg
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "product");

            builder.OwnsOne(b => b.SeoData, option => { 
                option.Property(p => p.MetaTitle).HasMaxLength(200);
                option.Property(p => p.MetaKeywords).HasMaxLength(2000);
                option.Property(p => p.Canonicial).HasMaxLength(2000);
            });

            builder.OwnsMany(b => b.ProductImages, option => {
                option.ToTable("Images", "product");
                //option.HasKey("Id");
                option.Property(p => p.ProductId).IsRequired();
                option.Property(p => p.ImageName).IsRequired();

            });

            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ImageName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasColumnType(typeof(decimal).Name).HasPrecision(18, 0).IsRequired();


        }
    }
}
