using DigiMenu.Domain.PageSettingAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.PageSettingAgg
{
    internal class PageSettingConfiguration : IEntityTypeConfiguration<PageSetting>
    {
        public void Configure(EntityTypeBuilder<PageSetting> builder)
        {
            builder.ToTable("PageSettings", "pagesetting");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Address).HasMaxLength(1000);
            builder.Property(p => p.BackgroundImageName).HasMaxLength(100);
            builder.Property(p => p.LogoImageName).HasMaxLength(100);
            builder.Property(p => p.PageTitle).IsRequired().HasMaxLength(100);
            builder.Property(p => p.SocialAddress).HasMaxLength(200);
            builder.Property(p => p.SocialTitle).HasMaxLength(100);
            builder.Property(p => p.Telephone).HasMaxLength(20);
            builder.Property(p => p.WebsiteAddress).HasMaxLength(100);

        }
    }
}
