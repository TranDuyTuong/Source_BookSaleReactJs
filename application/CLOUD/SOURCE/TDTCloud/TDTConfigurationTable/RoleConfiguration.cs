using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace TDTConfigurationTable
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Configuration table Role
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            // Configuration PrimaryKey
            builder.HasKey(x => x.Id);
            builder.HasKey(x => x.RoleID);
            // Configuration Propeties
            builder.Property(x => x.RoleID).IsRequired(true);
            builder.Property(x => x.RoleID).HasMaxLength(10);
            builder.Property(x => x.RoleID).HasColumnType("Nvarchar(10)");

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(150)");

            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.ContentLastUpdateDate).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDate).HasMaxLength(250);
            builder.Property(x => x.ContentLastUpdateDate).HasColumnType("Nvarchar(250)");

            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
