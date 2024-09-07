using DigiMenu.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.UserAgg
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "user");
            builder.HasKey(x => x.Id);
            builder.HasIndex(p => p.Username).IsUnique();

            builder.OwnsMany(b => b.Roles, option => {
                option.ToTable("Roles", "user");
                option.HasIndex(p => p.UserId);
            });

            builder.OwnsMany(b => b.UserTokens, option => {
                option.ToTable("Tokens", "user");
                option.HasKey(b => b.Id);

                option.Property(b => b.HashJwtToken)
                    .IsRequired()
                    .HasMaxLength(250);

                option.Property(b => b.HashRefreshToken)
                    .IsRequired()
                    .HasMaxLength(250);

                option.Property(b => b.Device)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.Username).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(200);

        }
    }
}
