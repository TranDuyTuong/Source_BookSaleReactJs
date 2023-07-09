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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// Configuration table UserRole
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");
            // Configuration PrimaryKey
            builder.HasKey(x => x.RoleID);
            builder.HasKey(x => x.UserID);
            // Configuration Propeties
            builder.Property(x => x.RoleID).IsRequired(true);
            builder.Property(x => x.RoleID).HasMaxLength(10);
            builder.Property(x => x.RoleID).HasColumnType("Nvarchar(10)");

            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.Delegator).IsRequired(true);
            builder.Property(x => x.EventCodeLimit).IsRequired(true);

            builder.Property(x => x.ContentLastUpdateDtae).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDtae).HasMaxLength(250);
            builder.Property(x => x.ContentLastUpdateDtae).HasColumnType("Nvarchar(250)");

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
