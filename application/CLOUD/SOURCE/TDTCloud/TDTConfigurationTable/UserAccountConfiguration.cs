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
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        /// <summary>
        /// Configuration Table UserAccount
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("UserAccounts");
            // Configuration PrimaryKey
            builder.HasKey(x => x.Id);
            builder.HasKey(x => x.UserID);
            // Configuration Propeties
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.UserID).HasMaxLength(150);

            builder.Property(x => x.PasswordHash).IsRequired(true);

            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.UserName).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.RemmenberAccount).IsRequired(false);
            builder.Property(x => x.IsActiver).IsRequired(true);
        }
    }
}
