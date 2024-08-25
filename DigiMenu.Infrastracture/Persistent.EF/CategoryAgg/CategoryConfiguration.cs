using DigiMenu.Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.CategoryAgg
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "category");

            //builder.HasKey(c => c.Id);
            builder.OwnsOne(b => b.SeoData, option => {
                option.Property(p => p.MetaTitle).HasMaxLength(200);
                option.Property(p => p.MetaKeywords).HasMaxLength(2000);
                option.Property(p => p.Canonicial).HasMaxLength(2000);
            });

            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ImageName).IsRequired();

        }
    }
}
