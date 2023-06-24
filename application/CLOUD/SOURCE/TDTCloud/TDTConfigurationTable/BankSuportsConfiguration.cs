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
    public class BankSuportsConfiguration : IEntityTypeConfiguration<BankSuports>
    {
        /// <summary>
        /// Configuration Table BankSuports
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<BankSuports> builder)
        {
            builder.ToTable("BankSuports");
            // Configuration PrimaryKey
            builder.HasKey(x => x.BankID);

            // Configuration Properties
            builder.Property(x => x.BankID).IsRequired(true);
            builder.Property(x => x.BankID).HasMaxLength(50);
            builder.Property(x => x.BankID).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(250)");

            builder.Property(x => x.BankCode).IsRequired(true);
            builder.Property(x => x.BankCode).HasMaxLength(50);
            builder.Property(x => x.BankCode).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.DateCreate).IsRequired(true);

            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.Content).IsRequired(false);
            builder.Property(x => x.Content).HasMaxLength(100);
            builder.Property(x => x.Content).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.UrlImageBank).IsRequired(true);
            builder.Property(x => x.UrlImageBank).HasColumnType("Nvarchar(MAX)");

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
